﻿using System;
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

        public long Login(string email, string password)
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

        public bool Registration(UserDomain userDomain)
        {
            var user = new User();
            user = Mapper.Map<User>(userDomain);
            Context.Users.Add(user);
            Context.SaveChanges();

            return true;
        }
    }
}
