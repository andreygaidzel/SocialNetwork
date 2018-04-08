using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.Domain.Enums;
using SocialNet.Domain.User;
using SocialNet.Security;
using SocialNET.BLL.Abstract.Services;

namespace SocialNet.BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; }
        private WebUserInfo UserInfo { get; }

        public UserService(IUserRepository userRepository, WebUserInfo userInfo)
        {
            UserRepository = userRepository;
            UserInfo = userInfo;
        }

        public List<UserDomain> List()
        {
            return UserRepository.List();
        }

        public UserDomain GetUser(long userId)
        {
            return UserRepository.GetUser(UserInfo.MyId, userId);
        }

        public List<UserDomain> GetFriends(UserRelationType type)
        {
            return UserRepository.GetFriends(UserInfo.MyId, type);
        }

        public List<UserDomain> Search(string searchWord)
        {
            return UserRepository.Search(searchWord);
        }

        public UserDomain ChangeRelation(long friendId, FriendStatus? status)
        {
            if (status == null)
            {
                return UserRepository.DeleteRelation(UserInfo.MyId, friendId);
            }
            else
            {
                return UserRepository.ChangeRelation(UserInfo.MyId, friendId, status.Value);
            } 
        }
    }
}
