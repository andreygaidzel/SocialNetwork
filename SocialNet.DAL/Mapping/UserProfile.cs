using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNet.DAL.Models;
using SocialNet.Domain.User;

namespace SocialNet.DAL.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDomain>();
            CreateMap<UserDomain, User>();
        }
    }
}
