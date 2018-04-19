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
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Avatar> Avatars { get; set; }

        /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
              modelBuilder.Entity<User>()
                  .HasMany(x => x.Friends)
                  .WithRequired()
                  .HasForeignKey(x => x.UserId);

              modelBuilder.Entity<Friendship>()
                  .HasRequired(x => x.UserFriend)
                  .WithMany()
                  .HasForeignKey(x => x.UserFriendId)
                  .WillCascadeOnDelete(false);
          }*/
    }
}
