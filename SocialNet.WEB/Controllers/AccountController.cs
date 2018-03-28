using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SocialNet.Domain.User;
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
        public bool Login([FromBody]UserDomain user)
        {
            var list = AccountService.List().FirstOrDefault(x => x.Name == user.Name && x.Pass == user.Pass);
            if (list != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}