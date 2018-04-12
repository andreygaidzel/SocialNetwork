using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Models.Base;

namespace SocialNet.DAL.Models
{
    public class User: EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public List<Avatar> Avatar { get; set; }

        public User()
        {
            Avatar = new List<Avatar>();
        }
    }
}
