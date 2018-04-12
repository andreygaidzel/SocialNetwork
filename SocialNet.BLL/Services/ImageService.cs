using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Abstract.Repositories;
using SocialNET.BLL.Abstract.Services;
using System.Web;
using System.Web.Http;

namespace SocialNet.BLL.Services
{
    public class ImageService : IImageService
    {
        private IImageRepository ImageRepository { get; }

    }
}
