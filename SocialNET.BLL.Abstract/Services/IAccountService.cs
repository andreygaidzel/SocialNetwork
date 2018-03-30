using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.User;

namespace SocialNET.BLL.Abstract.Services
{
    public interface IAccountService
    {
        long Login(string login, string password);
    }
}
