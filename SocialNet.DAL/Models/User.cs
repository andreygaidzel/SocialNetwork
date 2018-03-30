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
        public User()
        {
            Friends = new List<Friendship>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Friendship> Friends { get; set; }
    }
}
