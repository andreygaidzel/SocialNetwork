using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Comon;
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

        public UserDomain GetUser(long userId)
        {
            
            return UserRepository.GetUser(UserInfo.MyId, userId, GetPath.Host());
        }

        public List<UserDomain> GetFriends(UserRelation userRelation)
        {
            return UserRepository.GetFriends(UserInfo.MyId, userRelation);
        }

        public List<UserDomain> Search(string searchWord)
        {
            return UserRepository.Search(searchWord);
        }

        public UserDomain ChangeRelation(long userId, FriendStatus? friendStatus)
        {
            if (friendStatus == null)
            {
                return UserRepository.DeleteRelation(UserInfo.MyId, userId);
            }
            else
            {
                return UserRepository.ChangeRelation(UserInfo.MyId, userId, friendStatus.Value);
            } 
        }
    }
}
