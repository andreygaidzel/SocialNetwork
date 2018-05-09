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
                    FirstName = "Olia",
                    LastName = "Dmitrova",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Полоцк",
                    Password = "123456",
                    Email = "9ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 5,
                    FirstName = "Миша",
                    LastName = "Круг",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Орша",
                    Password = "123456",
                    Email = "8ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 6,
                    FirstName = "Юля",
                    LastName = "Слим",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "7ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 7,
                    FirstName = "Валя",
                    LastName = "Верхович",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "6ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 8,
                    FirstName = "Olia",
                    LastName = "Bulavka",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Минск",
                    Password = "123456",
                    Email = "5ola@mail.ru"
                });

                context.Users.Add(new User
                {
                    Id = 9,
                    FirstName = "Cаша",
                    LastName = "Черный",
                    DateOfBirth = new DateTime(1997, 1, 1),
                    City = "Солигорск",
                    Password = "123456",
                    Email = "4ola@mail.ru"
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
                    Status = FriendStatus.Friend,
                    ActionUserId = 1
                });
            }
        }
    }
}
