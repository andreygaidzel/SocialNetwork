using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc.Routing.Constraints;
using SocialNet.Domain.User;
using SocialNet.WEB.Models;
using SocialNET.BLL.Abstract.Services;

namespace SocialNet.WEB.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        public IAccountService AccountService { get; }

        public AccountController(IAccountService accountService)
        {
            AccountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public long Login([FromBody]LoginModel login)
        {
            return AccountService.Login(login.Email, login.Password);
        }

        [HttpPost]
        [Route("registration")]
        public bool Registration([FromBody]UserDomain user)
        {
            if (ModelState.IsValid)
            {
                return AccountService.Registration(user);
            }
            else
            {
                return false;
            }
                
        }
    }
}