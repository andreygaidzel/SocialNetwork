using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Models.Base;

namespace SocialNet.DAL.Models
{
    public class Friendship: EntityBase
    {
        public long UserId { get; set; }

        public long UserFriendId { get; set; }
        public User UserFriend { get; set; }
    }
}
