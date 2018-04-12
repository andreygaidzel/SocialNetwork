using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNET.BLL.Abstract.Services
{
    public interface IImageService
    {
        string AddAvatar(List<Stream> filesList);
    }
}
