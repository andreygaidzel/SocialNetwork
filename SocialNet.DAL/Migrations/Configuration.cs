using System.Collections.Generic;
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
                    Email = "dima@mail.ru",
                    Friends = new List<Friendship>
                    {
                        new Friendship {UserFriendId = 2},
                        new Friendship {UserFriendId = 3},
                    }
                });

                context.Users.Add(new User
                {
                    Id = 2,
                    Name = "Ilya",
                    Surname = "Goncharov",
                    Date = new DateTime(1993, 5, 1),
                    City = "Витебск",
                    Password = "123456",
                    Email = "ilya@mail.ru",
                    Friends = new List<Friendship>
                    {
                        new Friendship {UserFriendId = 1},
                        new Friendship {UserFriendId = 3},
                    }
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

                context.Users.Add(new User
                {
                    Id = 4,
                    Name = "Olia4",
                    Surname = "Buzova4",
                    Date = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "9ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 5,
                    Name = "Olia5",
                    Surname = "Buzova5",
                    Date = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "8ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 6,
                    Name = "Olia6",
                    Surname = "Buzova6",
                    Date = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "7ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 7,
                    Name = "Olia7",
                    Surname = "Buzova7",
                    Date = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "6ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 8,
                    Name = "Olia8",
                    Surname = "Buzova8",
                    Date = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "5ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 9,
                    Name = "Olia9",
                    Surname = "Buzova9",
                    Date = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "4ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 10,
                    Name = "Olia10",
                    Surname = "Buzova10",
                    Date = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "3ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 11,
                    Name = "Olia11",
                    Surname = "Buzova11",
                    Date = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "2ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 12,
                    Name = "Olia12",
                    Surname = "Buzova12",
                    Date = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "1ola@mail.ru"
                });
            }
        }
    }
}
