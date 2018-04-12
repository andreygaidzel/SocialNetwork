using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNet.DAL.Abstract.Repositories
{
    public interface IImageRepository
    {
        string AddAvatar(long myId);
        void SaveStream(string path, List<Stream> filesList);
    }
}
