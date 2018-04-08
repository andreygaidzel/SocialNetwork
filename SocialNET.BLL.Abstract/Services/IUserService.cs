using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.Enums;
using SocialNet.Domain.User;

namespace SocialNET.BLL.Abstract.Services
{
    public interface IUserService
    {
        UserDomain GetUser(long userId);
        List<UserDomain> GetFriends(UserRelation userRelation);
        List<UserDomain> Search(string searchWord);
        UserDomain ChangeRelation(long userId, FriendStatus? friendStatus);
    }
}
