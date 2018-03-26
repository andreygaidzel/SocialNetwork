using System.Web;
using System.Web.Http;
using LightInject;
using SocialNet.Configuration;

namespace SocialNet.WEB.App_Start
{
    public class InjectionConfig
    {
        public static ServiceContainer Container;

        public static IServiceContainer Configure()
        {
            Container = new ServiceContainer();

            Container.RegisterControllers();
            Container.RegisterApiControllers();

            DependencyResolver.Register(Container);

            Container.EnableMvc();
            Container.EnableWebApi(GlobalConfiguration.Configuration);

            return Container;
        }
    }
}