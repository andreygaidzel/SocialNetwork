using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace SocialNet.WEB.Helpers
{
    public class GetFiles
    {
        public HttpRequest Get()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            return httpRequest;
        }
    }
}