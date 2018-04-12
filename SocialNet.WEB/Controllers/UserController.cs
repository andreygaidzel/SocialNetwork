using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        [Route("getUser/{userId}")]
        public UserDomain GetUser(long userId)
        {
            return UserService.GetUser(userId);
        }

        [HttpGet]
        [Route("getFriends/{userRelation}")]
        public List<UserDomain> GetFriends(UserRelation userRelation)
        {
            return UserService.GetFriends(userRelation);
        }

        [HttpGet]
        [Route("search/{searchWord}")]
        public List<UserDomain> Search(string searchWord)
        {
            return UserService.Search(searchWord);
        }

        [HttpGet]
        [Route("changeRelation/{userId}/{friendStatus}")]
        public UserDomain ChangeRelation(long userId, FriendStatus? friendStatus)
        {
            return UserService.ChangeRelation(userId, friendStatus);
        }

        [HttpPost]
        [Route("lo")]
        public long Login([FromBody]Stream file)
        {
            return 1;

        }
    }
}