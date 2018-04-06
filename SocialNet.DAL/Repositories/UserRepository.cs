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
using SocialNet.Domain.Enums;

namespace SocialNet.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(SocialNetContext context) : base(context)
        {
        }

        public List<UserDomain> List()
        {
            var list = Context.Users.ToList();

            return Mapper.Map<List<UserDomain>>(list);
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

            var friendShip = Context.Friendships.FirstOrDefault(x => x.UserOneId == firstValue && x.UserTwoId == secondValue);

            return friendShip;
        }
        
        public UserDomain GetUser(long myId, long userId)
        {
            var user = Context.Users.First(x => x.Id == userId);        

            var userDomain = Mapper.Map<UserDomain>(user);

            userDomain.RelationType = GetRelationType(myId, userId);

            return userDomain;
        }

        public UserRelationType GetRelationType(long myId, long userId)
        {
            UserRelationType type;

            if (myId == userId)
            {
                type = UserRelationType.I;
            }
            else
            {
                var friendShip = GetFriendship(myId, userId);

                if (friendShip == null)
                {
                    type = UserRelationType.None;
                }
                else
                {
                    switch (friendShip.Status)
                    {
                        case FriendStatus.Friend:
                            type = UserRelationType.Friend;
                            break;
                        case FriendStatus.Blocked:
                            type = UserRelationType.Blocked;
                            break;
                        case FriendStatus.Pending when friendShip.ActionUserId == myId:
                        case FriendStatus.Rejected:
                            type = UserRelationType.OutPending;
                            break;
                        case FriendStatus.Pending when friendShip.ActionUserId == userId:
                            type = UserRelationType.InPending;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return type;
        }

        public List<UserDomain> GetFriends(long id, UserRelationType type)
        {
            var friendship = Context.Friendships.AsQueryable();

            switch (type)
            {
                case UserRelationType.Friend:
                    friendship = friendship
                        .Where(x => (x.UserOneId == id || x.UserTwoId == id) 
                                    && x.Status == FriendStatus.Friend);
                    break;
                case UserRelationType.InPending:
                    friendship = friendship
                        .Where(x => (x.UserOneId == id || x.UserTwoId == id) 
                                    && x.Status == FriendStatus.Pending 
                                    && x.ActionUserId != id);
                    break;
                case UserRelationType.OutPending:
                    friendship = friendship
                        .Where(x => (x.UserOneId == id || x.UserTwoId == id) 
                                    && x.Status == FriendStatus.Pending 
                                    && x.ActionUserId == id);
                    break;
            }

            var friendsId = friendship.Select(x => x.UserOneId == id ? x.UserTwoId : x.UserOneId);
            var friends = Context.Users.Where(x => friendsId.Contains(x.Id)).ToList();

            return Mapper.Map<List<UserDomain>>(friends);
        }

        public List<UserDomain> Search(string searchWord)
        {
            var users = Context.Users.Where(x => x.FirstName.Contains(searchWord) || x.LastName.Contains(searchWord))
                .ToList();

            return Mapper.Map<List<UserDomain>>(users);
        }

        public UserDomain ChangeRelation(long friendId, long myId, FriendStatus status)
        {
            var friendShip = GetFriendship(myId, friendId);
            
            if (friendShip != null)
            {
                friendShip.Status = status;
                friendShip.ActionUserId = myId;
            }
            else
            {
                Context.Friendships.Add(new Friendship
                {
                    UserOneId = (friendId < myId) ? friendId : myId,
                    UserTwoId = (friendId > myId) ? friendId : myId,
                    Status = status,
                    ActionUserId = myId
                });
            }

            Context.SaveChanges();

            var user = GetUser(myId, friendId);

            return Mapper.Map<UserDomain>(user);
        }
    }
}