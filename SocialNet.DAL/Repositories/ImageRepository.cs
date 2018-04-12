using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNet.DAL.Abstract.Repositories;
using SocialNet.DAL.Repositories.Base;

namespace SocialNet.DAL.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(SocialNetContext context) : base(context)
        {
        }
    }
}
