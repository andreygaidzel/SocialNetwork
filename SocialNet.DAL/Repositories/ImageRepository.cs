using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.DAL.Models;
using SocialNet.DAL.Repositories.Base;

namespace SocialNet.DAL.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(SocialNetContext context) : base(context)
        {
        }

        public string AddAvatar(long myId)
        {
            var number = Context.Avatar.Count();
            var newPath = "/Images/User_" + myId + "_Avatar_" + number + ".jpg";

            var avatar = new Avatar
            {
                Path = newPath,
                Active = true,
                UserId = myId
            };

            Context.Avatar.Add(avatar);
            Context.SaveChanges();

            return newPath;
        }

        public void SaveStream(string path, List<Stream> filesList)
        {
            if (filesList.Count == 1)
            {
                var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                filesList[0].CopyTo(fileStream);
                fileStream.Dispose();
            }
            else
            {
                new Exception("Не то с файлами");
            }
        }
    }
}