using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.Enums;

namespace SocialNet.Domain.User
{
    public class UserDomain
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public UserRelation RelationType { get; set; }
        public DateTime CreateData { get; set; }
    }
}
