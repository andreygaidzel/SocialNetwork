using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Comon;

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
        public string AvatarPath => $"{GetPath.Host()}{AvatarName}";
        public string IconPath => $"{GetPath.Host()}{IconName}";
    }
}
