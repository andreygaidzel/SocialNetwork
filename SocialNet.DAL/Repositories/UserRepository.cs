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
using System.Data.Entity;

namespace SocialNet.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(SocialNetContext context) : base(context)
        {
        }

        public List<UserDomain> List()
        {
            var list = Context.Users.ToList();

            return Mapper.Map<List<UserDomain>>(list);
        }

        public UserDomain GetUser(long id)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == id);

            return Mapper.Map<UserDomain>(user);
        }

        public List<UserDomain> GetFriends(long id)
        {
            var friends = Context.Users.Include(x => x.Friends.Select(y => y.UserFriend)).First(x => x.Id == id).Friends;
            var frendlist = friends.Select(x => x.UserFriend).ToList();

            return Mapper.Map<List<UserDomain>>(frendlist);
        }

        public List<UserDomain> Search(string searchWord)
        {
            var users = Context.Users.Where(x => x.Name.Contains(searchWord) || x.Surname.Contains(searchWord)).ToList();

            return Mapper.Map<List<UserDomain>>(users);
        }
    }
}
