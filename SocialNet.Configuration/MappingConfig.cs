using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNet.DAL.Mapping;

namespace SocialNet.Configuration
{
    public static class MappingConfig
    {
        public static void Register()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<UserProfile>();
            });
        }
    }
}
