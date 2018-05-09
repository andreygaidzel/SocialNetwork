using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.Enums;

namespace SocialNet.Domain.User
{
    public class UserDomain
    {
        public long Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string City { get; set; }
        public UserRelation RelationType { get; set; }
        public DateTime CreateData { get; set; }
        public List<AvatarDomain> Avatars { get; set; }
    }
}
