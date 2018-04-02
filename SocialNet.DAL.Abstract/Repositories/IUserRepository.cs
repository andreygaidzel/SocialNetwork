using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.User;

namespace SocialNet.DAL.Abstract.Repositories
{
    public interface IUserRepository
    {
        List<UserDomain> List();
        UserDomain GetUser(long id);
        List<UserDomain> GetFriends(long id);
    }
}
