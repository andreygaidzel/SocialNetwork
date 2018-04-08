namespace SocialNet.Domain.Enums
{
    public enum UserRelation
    {
        None = 0,
        I = 1,
        Friend = 2,
        InFollower = 3,
        OutFollower = 4,
        InBlocked = 5,
        OutBlocked = 6,
        DoubleBlocked = 7
    }
}