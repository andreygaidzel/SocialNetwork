using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SocialNET.BLL.Abstract.Services;

namespace SocialNet.WEB.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        public IImageService ImageService { get; }

        public ImageController(IImageService imageService)
        {
            ImageService = imageService;
        }

        [HttpPost]
        [Route("addavatar")]
        public string AddAvatar()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Images/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return "tt";
        }
    }
}