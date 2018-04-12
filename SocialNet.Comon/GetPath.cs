using System;
using System.Web;

namespace SocialNet.Comon
{
    public class GetPath
    {
        public static string Path()
        {
           return HttpContext.Current.Server.MapPath(".");
        }
       
    }
}
