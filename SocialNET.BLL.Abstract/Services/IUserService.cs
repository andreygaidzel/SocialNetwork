using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.User;

namespace SocialNET.BLL.Abstract.Services
{
    public interface IUserService
    {
        List<UserDomain> List();
        UserDomain GetUser(long id);
    }
}
