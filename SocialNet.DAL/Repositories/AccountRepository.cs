using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.DAL.Models;
using SocialNet.DAL.Repositories.Base;
using SocialNet.Domain.User;

namespace SocialNet.DAL.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(SocialNetContext context) : base(context)
        {
        }

        public int Login(string email, string password)
        {
            var user = Context.Users.ToList().FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                return user.Id;
            }
            else
            {
                return -1;
            }
        }
    }
}
