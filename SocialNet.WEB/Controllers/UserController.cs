using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("getUser/{myId}/{userId}")]
        public UserDomain GetUser(long myId, long userId)
        {
            return UserService.GetUser(myId, userId);
        }

        [HttpGet]
        [Route("getFriends/{id}/{type}")]
        public List<UserDomain> GetFriends(long id, UserRelationType type)
        {
            return UserService.GetFriends(id, type);
        }

        [HttpGet]
        [Route("search/{searchWord}")]
        public List<UserDomain> Search(string searchWord)
        {
            return UserService.Search(searchWord);
        }

        [HttpGet]
        [Route("changeRelation/{friendId}/{myId}/{status}")]
        public UserDomain ChangeRelation(long friendId, long myId, FriendStatus status)
        {
            return UserService.ChangeRelation(friendId, myId, status);
        }
    }
}