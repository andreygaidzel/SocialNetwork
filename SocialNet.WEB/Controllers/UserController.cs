using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SocialNet.Domain.Enums;
using SocialNet.Domain.User;
using SocialNET.BLL.Abstract.Services;

namespace SocialNet.WEB.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public IUserService UserService { get; }

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        [Route("list")]
        public List<UserDomain> List()
        {
            return UserService.List();
        }

        [HttpGet]
        [Route("getUser/{userId}")]
        public UserDomain GetUser(long userId)
        {
            return UserService.GetUser(userId);
        }

        [HttpGet]
        [Route("getFriends/{type}")]
        public List<UserDomain> GetFriends(UserRelationType type)
        {
            return UserService.GetFriends(type);
        }

        [HttpGet]
        [Route("search/{searchWord}")]
        public List<UserDomain> Search(string searchWord)
        {
            return UserService.Search(searchWord);
        }

        [HttpGet]
        [Route("changeRelation/{friendId}/{status}")]
        public UserDomain ChangeRelation(long friendId, FriendStatus? status)
        {
            return UserService.ChangeRelation(friendId, status);
        }
    }
}