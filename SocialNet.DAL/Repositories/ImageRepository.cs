using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.DAL.Models;
using SocialNet.DAL.Repositories.Base;
using SocialNet.Domain.User;

namespace SocialNet.DAL.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(SocialNetContext context) : base(context)
        {
        }

        public AvatarDomain AddAvatar(long myId, string name)
        {
            var avatar = new Avatar
            {
                Path = name,
                Active = true,
                UserId = myId
            };

            Context.Avatar.Add(avatar);
            Context.SaveChanges();

            return Mapper.Map<AvatarDomain>(avatar);
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