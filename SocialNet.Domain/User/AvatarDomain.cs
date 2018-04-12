using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNet.Domain.User
{
    public class AvatarDomain
    {
        public string Path { get; set; }
        public bool Active { get; set; }
        public long UserId { get; set; }
    }
}
