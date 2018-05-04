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
using SocialNet.WEB.Models;
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
        public AvatarDomain AddAvatar([FromBody]AvatarModel model)
        {
            return ImageService.AddAvatar(model.Avatar, model.Icon);
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
