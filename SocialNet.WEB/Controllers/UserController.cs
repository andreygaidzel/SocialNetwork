using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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
        [Route("getUser/{id}")]
        public UserDomain GetUser(long id)
        {
            return UserService.GetUser(id);
        }

        [HttpPost]
        [Route("getFriends")]
        public List<UserDomain> GetFriends([FromBody]long id)
        {
            return UserService.GetFriends(id);
        }

        [HttpGet]
        [Route("search/{searchWord}")]
        public List<UserDomain> Search(string searchWord)
        {
            return UserService.Search(searchWord);
        }
    }
}