using SocialNet.DAL.Models;

namespace SocialNet.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialNet.DAL.SocialNetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SocialNet.DAL.SocialNetContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Id = 1,
                    Name = "Dmitriy",
                    Pass = "123456"
                });

                context.Users.Add(new User
                {
                    Id = 2,
                    Name = "Ilya",
                    Pass = "123456"
                });

                context.Users.Add(new User
                {
                    Id = 3,
                    Name = "Olia",
                    Pass = "123456"
                });
            }
        }
    }
}
