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
    public class Friendship: EntityBase
    {
        public long UserOneId { get; set; }

        public long UserTwoId { get; set; }

        public FriendStatus Status { get; set; }
    
        public long ActionUserId { get; set; }
    }
}
