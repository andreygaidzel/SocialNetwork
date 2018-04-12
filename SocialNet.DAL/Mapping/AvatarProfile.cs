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
    public class AvatarProfile: Profile
    {
        public AvatarProfile()
        {
            CreateMap<Avatar, AvatarDomain>();
            CreateMap<AvatarDomain, Avatar>();
        }
    }
}
