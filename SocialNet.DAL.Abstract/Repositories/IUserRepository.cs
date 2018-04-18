using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.Enums;
using SocialNet.Domain.User;

namespace SocialNet.DAL.Abstract.Repositories
{
    public interface IUserRepository
    {
        UserDomain GetUser(long myId, long userId);
        List<UserDomain> GetFriends(long myId, UserRelation userRelation);
        List<UserDomain> Search(string searchWord);
        UserDomain ChangeRelation(long myId, long userId, FriendStatus friendStatus);
        UserDomain DeleteRelation(long myId, long userId);
    }
}
