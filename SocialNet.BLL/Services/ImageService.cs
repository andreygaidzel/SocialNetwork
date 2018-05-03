using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Abstract.Repositories;
using SocialNET.BLL.Abstract.Services;
using System.Web;
using System.Web.Http;
using SocialNet.Comon;
using SocialNet.Domain.User;
using SocialNet.Security;

namespace SocialNet.BLL.Services
{
    public class ImageService : IImageService
    {
        private IImageRepository ImageRepository { get; }
        private WebUserInfo UserInfo { get; }

        public ImageService(IImageRepository imageRepository, WebUserInfo userInfo)
        {
            ImageRepository = imageRepository;
            UserInfo = userInfo;
        }

        public AvatarDomain AddAvatar(string avatar)
        {
            var random = Guid.NewGuid().ToString("n");
            var imageName = "User_" + UserInfo.MyId + "_IMG_" + random + ".jpg";
            var startupPath = GetPath.BaseDirectory() + "Images\\" + imageName;

            ImageRepository.SaveBase64(startupPath, avatar);

            return ImageRepository.AddAvatar(UserInfo.MyId, imageName);
        }

        public AvatarDomain RemoveAvatar()
        {
            return ImageRepository.RemoveAvatar(UserInfo.MyId);
        }

        public List<AvatarDomain> GetAvatars(long userId)
        {
            return ImageRepository.GetAvatars(userId);
        }
    }
}
