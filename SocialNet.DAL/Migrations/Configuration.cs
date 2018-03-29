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
                    Surname = "Buzo",
                    Date = new DateTime(1993, 11, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "dima@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 2,
                    Name = "Ilya",
                    Surname = "Goncharov",
                    Date = new DateTime(1993, 5, 1),
                    City = "Витебск",
                    Password = "123456",
                    Email = "ilya@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 3,
                    Name = "Olia",
                    Surname = "Buzova",
                    Date = new DateTime(1997,1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "ola@mail.ru"
                });
            }
        }
    }
}
