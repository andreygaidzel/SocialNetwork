using System.Collections.Generic;
using SocialNet.DAL.Models;
using SocialNet.Domain.Enums;

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
                    FirstName = "Dmitriy",
                    LastName = "Buzo",
                    DateOfBirth = new DateTime(1993, 11, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "dima@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 2,
                    FirstName = "Ilya",
                    LastName = "Goncharov",
                    DateOfBirth = new DateTime(1993, 5, 1),
                    City = "Витебск",
                    Password = "123456",
                    Email = "ilya@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 3,
                    FirstName = "Olia",
                    LastName = "Buzova",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 4,
                    FirstName = "Olia4",
                    LastName = "Buzova4",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "9ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 5,
                    FirstName = "Olia5",
                    LastName = "Buzova5",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "8ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 6,
                    FirstName = "Olia6",
                    LastName = "Buzova6",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "7ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 7,
                    FirstName = "Olia7",
                    LastName = "Buzova7",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "6ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 8,
                    FirstName = "Olia8",
                    LastName = "Buzova8",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "5ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 9,
                    FirstName = "Olia9",
                    LastName = "Buzova9",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "4ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 10,
                    FirstName = "Olia10",
                    LastName = "Buzova10",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "3ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 11,
                    FirstName = "Olia11",
                    LastName = "Buzova11",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "2ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 12,
                    FirstName = "Olia12",
                    LastName = "Buzova12",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "1ola@mail.ru"
                });
            }

            if (!context.Friendships.Any())
            {
                context.Friendships.Add(new Friendship
                {
                    Id = 1,
                    UserOneId = 1,
                    UserTwoId = 2,
                    Status = FriendStatus.Friend,
                    ActionUserId = 1
                });

                context.Friendships.Add(new Friendship
                {
                    Id = 2,
                    UserOneId = 1,
                    UserTwoId = 3,
                    Status = FriendStatus.Friend,
                    ActionUserId = 1
                });

                context.Friendships.Add(new Friendship
                {
                    Id = 3,
                    UserOneId = 1,
                    UserTwoId = 4,
                    Status = FriendStatus.Blocked,
                    ActionUserId = 4
                });

                context.Friendships.Add(new Friendship
                {
                    Id = 4,
                    UserOneId = 1,
                    UserTwoId = 5,
                    Status = FriendStatus.FollowerPendingInFriend,
                    ActionUserId = 1
                });

                context.Friendships.Add(new Friendship
                {
                    Id = 5,
                    UserOneId = 1,
                    UserTwoId = 6,
                    Status = FriendStatus.Follower,
                    ActionUserId = 1
                });

                context.Friendships.Add(new Friendship
                {
                    Id = 6,
                    UserOneId = 1,
                    UserTwoId = 7,
                    Status = FriendStatus.Blocked,
                    ActionUserId = 1
                });
            }
        }
    }
}
