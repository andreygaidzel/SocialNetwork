using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Models.Base;
using SocialNet.Domain.Enums;

namespace SocialNet.DAL.Models
{
    public class Avatar: EntityBase
    {
        public string Path { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
