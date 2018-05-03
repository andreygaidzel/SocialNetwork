using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNet.Comon;
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
            var oldAvatar = Context.Avatars.FirstOrDefault(x => x.UserId == myId && x.Active == true);

            if (oldAvatar != null)
            {
                oldAvatar.Active = false;
            }
            var avatar = new Avatar
            {
                Path = name,
                Active = true,
                UserId = myId
            };

            Context.Avatars.Add(avatar);
            Context.SaveChanges();

            return Mapper.Map<AvatarDomain>(avatar);
        }

        public AvatarDomain RemoveAvatar(long myId)
        {
            var avatar = Context.Avatars.First(x => x.UserId == myId && x.Active == true);
            var avatarName = avatar.Path;
            Context.Avatars.Remove(avatar);
            FileHelper.DeleteImage(avatarName);

            var oldAvatar = Context.Avatars.OrderByDescending(x => x.Id).FirstOrDefault(x => x.UserId == myId && x.Active == false);

            if (oldAvatar != null)
            {
                oldAvatar.Active = true;
            }

            Context.SaveChanges();

            return Mapper.Map<AvatarDomain>(oldAvatar);
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

        public void SaveBase64(string path, string avatar)
        {
            byte[] result = Convert.FromBase64String(avatar.Split(',')[1]);
           // var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(avatar);
            
            File.WriteAllBytes(path, result);
        }

        public List<AvatarDomain> GetAvatars(long userId)
        {
            var avatars = Context.Avatars.OrderByDescending(x => x.Id).Where(x => x.UserId == userId).ToList();

            return Mapper.Map<List<AvatarDomain>>(avatars);
        }
    }
}