using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.DAL.Repositories.Base;
using SocialNet.Domain.User;

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
    }
}
