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

            return ImageService.AddAvatar(filesList);
        }

        [HttpGet]
        [Route("removeavatar")]
        public AvatarDomain RemoveAvatar()
        {
            return ImageService.RemoveAvatar();
        }

        [HttpGet]
        [Route("getavatars/{userId}")]
        public List<AvatarDomain> GetAvatars(long userId)
        {
            return ImageService.GetAvatars(userId);
        }
    }
}
