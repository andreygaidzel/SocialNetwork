using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.Domain.User;

namespace SocialNet.DAL.Abstract.Repositories
{
    public interface IImageRepository
    {
        AvatarDomain AddAvatar(long myId, string avatar, string icon);
        void SaveStream(string path, List<Stream> filesList);
        void SaveBase64(string path, string avatar);
        AvatarDomain RemoveAvatar(long myId);
        List<AvatarDomain> GetAvatars(long userId);
    }
}
