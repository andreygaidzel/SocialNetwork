
using System;
using System.Reflection.Emit;

namespace SocialNet.DAL.Models.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            CreateData = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public DateTime CreateData { get; set; }
    }
}
