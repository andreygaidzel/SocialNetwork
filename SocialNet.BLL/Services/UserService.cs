﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.Domain.User;
using SocialNET.BLL.Abstract.Services;

namespace SocialNet.BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; }

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public List<UserDomain> List()
        {
            return UserRepository.List();
        }

        public UserDomain GetUser(long id)
        {
            return UserRepository.GetUser(id);
        }

        public List<UserDomain> GetFriends(long id)
        {
            return UserRepository.GetFriends(id);
        }

        public List<UserDomain> Search(string searchWord)
        {
            return UserRepository.Search(searchWord);
        }
    }
}
