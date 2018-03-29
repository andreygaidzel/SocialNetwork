using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.User;

namespace SocialNet.DAL.Abstract.Repositories
{
    public interface IAccountRepository
    {
        int Login(string email, string pass);
    }
}
