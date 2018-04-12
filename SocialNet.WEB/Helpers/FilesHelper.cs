using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace SocialNet.WEB.Helpers
{
    public class FilesHelper
    {
        public static List<Stream> Get()
        {
            var httpRequest = HttpContext.Current.Request;
            var filesList = new List<Stream>();

            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var fileStream = postedFile.InputStream;
                   
                    filesList.Add(fileStream);
                }
            }

            return filesList;
        }
    }
}
