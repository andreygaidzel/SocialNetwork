using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SocialNet.Domain.User;
using SocialNet.WEB.Helpers;
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
        public AvatarDomain AddAvatar()
        {
            var test1 = Directory.GetCurrentDirectory();
            HttpContext.Current.Server.MapPath("z");

            var filesList = FilesHelper.Get();
            var host = HttpContext.Current.Request.Url.Authority;

            //  HttpResponseMessage result = null;
            // var httpRequest = HttpContext.Current.Request;

            // var newName = ImageService.AddAvatar(filesList);

            /*  if (filesList.Count > 0)
              {
                  //  var docfiles = new List<string>();
                  foreach (string file in filesList)
                  {
                      var postedFile = httpRequest.Files[file];
                      var filePath = HttpContext.Current.Server.MapPath("~" + newName);
                      postedFile.SaveAs(filePath);
                      // docfiles.Add(filePath);
                  }

                  // result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
              }
              /* else
               {
                   result = Request.CreateResponse(HttpStatusCode.BadRequest);
               }*/

            return ImageService.AddAvatar(filesList);
        }
    }
}
