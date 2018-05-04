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

        public AvatarDomain AddAvatar(string avatar, string icon)
        {
            var random = Guid.NewGuid().ToString("n");
            var imageName = "User_" + UserInfo.MyId + "_IMG_" + random + ".jpg";
            var startupPath = GetPath.BaseDirectory() + "Images\\" + imageName;
            var startupPathIcon = GetPath.BaseDirectory() + "Images\\" + "Icon_" + imageName;

            ImageRepository.SaveBase64(startupPath, avatar);
            ImageRepository.SaveBase64(startupPathIcon, icon);

            return ImageRepository.AddAvatar(UserInfo.MyId, imageName, "Icon_" + imageName);
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
