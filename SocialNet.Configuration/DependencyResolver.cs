using LightInject;
using SocialNet.BLL.Services;
using SocialNet.DAL;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.DAL.Repositories;
using SocialNet.Security;
using SocialNET.BLL.Abstract.Services;

namespace SocialNet.Configuration
{
    public class DependencyResolver
    {
        public static void Register(ServiceContainer container)
        {
            container.Register<IUserRepository, UserRepository>();
            container.Register<IAccountRepository, AccountRepository>();

            container.Register<IAccountService, AccountService>();
            container.Register<IUserService, UserService>();
            
            container.Register<SocialNetContext>(new PerScopeLifetime());

            container.Register<WebUserInfo>();
        }
    }
}
