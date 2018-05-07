using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.DAL.Models;
using SocialNet.DAL.Repositories.Base;
using SocialNet.Domain.User;
using System.Data.Entity;
using SocialNet.Comon;
using SocialNet.Domain.Enums;

namespace SocialNet.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(SocialNetContext context) : base(context)
        {
        }

        public Friendship GetFriendship(long myId, long userId)
        {
            long firstValue;
            long secondValue;

            if (userId < myId)
            {
                firstValue = userId;
                secondValue = myId;
            }
            else
            {
                firstValue = myId;
                secondValue = userId;
            }

            return Context.Friendships.FirstOrDefault(x => x.UserOneId == firstValue && x.UserTwoId == secondValue);
        }
        
        public UserDomain GetUser(long myId, long userId)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == userId);
                
            var userDomain = Mapper.Map<UserDomain>(user);
            var avatar = Context.Avatars.FirstOrDefault(x => x.UserId == userId && x.Active == true);
            var avatars = new List<Avatar>() {avatar};

            userDomain.RelationType = GetUserRelation(myId, userId);

            if (avatar != null)
            {
                userDomain.Avatars = Mapper.Map<List<AvatarDomain>>(avatars);
            }
    
            return userDomain;
        }

        public UserRelation GetUserRelation(long myId, long userId)
        {
            UserRelation userRelation;

            if (myId == userId)
            {
                userRelation = UserRelation.I;
            }
            else
            {
                var friendShip = GetFriendship(myId, userId);

                if (friendShip == null)
                {
                    userRelation = UserRelation.None;
                }
                else
                {
                    switch (friendShip.Status)
                    {
                        case FriendStatus.Friend:
                            userRelation = UserRelation.Friend;
                            break;
                        case FriendStatus.Blocked when friendShip.ActionUserId == myId:
                            userRelation = UserRelation.OutBlocked;
                            break;
                        case FriendStatus.Blocked when friendShip.ActionUserId == userId:
                            userRelation = UserRelation.InBlocked;
                            break;
                        case FriendStatus.FollowerPendingInFriend when friendShip.ActionUserId == myId:
                        case FriendStatus.Follower when friendShip.ActionUserId == myId:
                            userRelation = UserRelation.OutFollower;
                            break;
                        case FriendStatus.FollowerPendingInFriend when friendShip.ActionUserId == userId:
                        case FriendStatus.Follower when friendShip.ActionUserId == userId:
                            userRelation = UserRelation.InFollower;
                            break;
                        case FriendStatus.DoubleBlocked:
                            userRelation = UserRelation.DoubleBlocked;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return userRelation;
        }

        public List<UserDomain> GetFriends(long myId, UserRelation userRelation)
        {
            var friendship = Context.Friendships.AsQueryable();

            switch (userRelation)
            {
                case UserRelation.Friend:
                    friendship = friendship
                        .Where(x => (x.UserOneId == myId || x.UserTwoId == myId) 
                                    && x.Status == FriendStatus.Friend);
                    break;
                case UserRelation.InFollower:
                    friendship = friendship
                        .Where(x => (x.UserOneId == myId || x.UserTwoId == myId) 
                                    && x.Status == FriendStatus.FollowerPendingInFriend 
                                    && x.ActionUserId != myId);
                    break;
                case UserRelation.OutFollower:
                    friendship = friendship
                        .Where(x => (x.UserOneId == myId || x.UserTwoId == myId) 
                                    && x.Status == FriendStatus.FollowerPendingInFriend 
                                    && x.ActionUserId == myId);
                    break;
            }

            var friendsId = friendship.Select(x => x.UserOneId == myId ? x.UserTwoId : x.UserOneId);
            var friends = Context.Users.Where(x => friendsId.Contains(x.Id))
                .Select(x => new
                {
                    user = x,
                    avatarActive = x.Avatars.FirstOrDefault(y => y.Active == true)
                })
                .AsEnumerable()
                .Select(x => x.user)
                .ToList();

            var tt = Mapper.Map<List<UserDomain>>(friends);
            return tt;
        }

        public List<UserDomain> Search(string searchWord)
        {
            var users = Context.Users
                .Where(x => x.FirstName.Contains(searchWord) || x.LastName.Contains(searchWord))
                .ToList();

            return Mapper.Map<List<UserDomain>>(users);
        }

        public UserDomain ChangeRelation(long myId, long userId, FriendStatus friendStatus)
        {
            var friendShip = GetFriendship(myId, userId);
            
            if (friendShip != null)
            {
                switch (friendStatus)
                {
                    case FriendStatus.Follower:
                        friendShip.Status = friendStatus;
                        friendShip.ActionUserId = userId;
                        break;
                    case FriendStatus.Blocked when friendShip.Status == FriendStatus.Blocked && friendShip.ActionUserId != myId:
                        friendShip.Status = FriendStatus.DoubleBlocked;
                        break;
                    default:
                        friendShip.Status = friendStatus;
                        friendShip.ActionUserId = myId;
                        break;
                }
            }
            else
            {
                Context.Friendships.Add(new Friendship
                {
                    UserOneId = (userId < myId) ? userId : myId,
                    UserTwoId = (userId > myId) ? userId : myId,
                    Status = friendStatus,
                    ActionUserId = myId
                });
            }

            Context.SaveChanges();

            var user = GetUser(myId, userId);

            return Mapper.Map<UserDomain>(user);
        }

        public UserDomain DeleteRelation(long myId, long userId)
        {
            var friendShip = GetFriendship(myId, userId);

            if (friendShip.Status == FriendStatus.DoubleBlocked)
            {
                friendShip.Status = FriendStatus.Blocked;
                friendShip.ActionUserId = userId;
            }
            else
            {
                Context.Friendships.Remove(friendShip);
            }
            
            Context.SaveChanges();

            var user = GetUser(myId, userId);

            return Mapper.Map<UserDomain>(user);
        }
    }
}