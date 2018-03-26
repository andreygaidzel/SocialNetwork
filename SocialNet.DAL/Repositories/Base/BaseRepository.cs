namespace SocialNet.DAL.Repositories.Base
{
    public class BaseRepository
    {
        public SocialNetContext Context { get; }

        public BaseRepository(SocialNetContext context)
        {
            Context = context;
        }
    }
}
