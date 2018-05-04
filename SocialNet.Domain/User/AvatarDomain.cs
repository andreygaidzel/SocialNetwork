using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNet.Domain.User
{
    public class AvatarDomain
    {
        public long Id { get; set; }
        public string AvatarName { get; set; }
        public string IconName { get; set; }
        public bool Active { get; set; }
        public long UserId { get; set; }
        public DateTime CreateData { get; set; }
        public string FullPath => $"http://localhost:60415/Images/{AvatarName}";
    }
}
