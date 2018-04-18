using System;
using System.Web;

namespace SocialNet.Comon
{
    public class GetPath
    {
        public static string BaseDirectory()
        {
           return HttpContext.Current.Server.MapPath("/");
        }

        public static string Host()
        {
            return HttpContext.Current.Request.Url.Authority;
        }

    }
}
