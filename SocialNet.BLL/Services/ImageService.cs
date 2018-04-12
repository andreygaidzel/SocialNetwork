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

        public string AddAvatar(List<Stream> filesList)
        {
            var dir = Directory.GetCurrentDirectory();
            string startupPath = GetPath.Path() + "\\hui.jpg";
            ImageRepository.SaveStream(startupPath, filesList);
            return ImageRepository.AddAvatar(UserInfo.MyId);
        }

    }
}
