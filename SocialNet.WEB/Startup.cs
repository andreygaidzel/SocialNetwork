using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using SocialNet.Configuration;
using SocialNet.WEB.App_Start;

[assembly: OwinStartup(typeof(SocialNet.WEB.Startup))]
namespace SocialNet.WEB
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var container = InjectionConfig.Configure();

            MappingConfig.Register();
        }
    }
}