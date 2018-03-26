using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Models;

namespace SocialNet.DAL
{
    public class SocialNetContext : DbContext
    {
        public SocialNetContext() : base("SocialNet")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
