using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.Domain.Enums;
using SocialNet.Domain.User;
using SocialNET.BLL.Abstract.Services;

namespace SocialNet.BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; }

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public List<UserDomain> List()
        {
            return UserRepository.List();
        }

        public UserDomain GetUser(long myId, long userId)
        {
            return UserRepository.GetUser(myId, userId);
        }

        public List<UserDomain> GetFriends(long id, UserRelationType type)
        {
            return UserRepository.GetFriends(id, type);
        }

        public List<UserDomain> Search(string searchWord)
        {
            return UserRepository.Search(searchWord);
        }

        public UserDomain ChangeRelation(long friendId, long myId, FriendStatus status)
        {
            return UserRepository.ChangeRelation(friendId, myId, status);
        }
    }
}
