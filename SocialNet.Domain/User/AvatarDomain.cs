using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNet.Domain.User
{
    public class AvatarDomain
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public bool Active { get; set; }
        public long UserId { get; set; }
        public DateTime CreateData { get; set; }
        public string FullPath => $"http://localhost:60415/Images/{Path}";
    }
}
