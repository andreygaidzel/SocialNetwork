using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.User;

namespace SocialNET.BLL.Abstract.Services
{
    public interface IImageService
    {
        AvatarDomain AddAvatar(string avatar, string icon);
        AvatarDomain RemoveAvatar();
        List<AvatarDomain> GetAvatars(long userId);
    }
}
