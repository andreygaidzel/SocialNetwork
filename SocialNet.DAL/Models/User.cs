using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Models.Base;

namespace SocialNet.DAL.Models
{
    public class User: EntityBase
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string City { get; set; }
        public List<Avatar> Avatars { get; set; }

        public User()
        {
            Avatars = new List<Avatar>();
        }
    }
}
