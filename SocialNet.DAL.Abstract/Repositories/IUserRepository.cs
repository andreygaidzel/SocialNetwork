﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.Enums;
using SocialNet.Domain.User;

namespace SocialNet.DAL.Abstract.Repositories
{
    public interface IUserRepository
    {
        List<UserDomain> List();
        UserDomain GetUser(long myId, long userId);
        List<UserDomain> GetFriends(long id, UserRelationType type);
        List<UserDomain> Search(string searchWord);
        UserDomain ChangeRelation(long friendId, long myId, FriendStatus status);
    }
}
