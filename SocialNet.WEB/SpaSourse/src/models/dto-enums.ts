export enum UserRelation
{
  None          = 0,
  I             = 1,
  Friend        = 2,
  InFollower    = 3,
  OutFollower   = 4,
  InBlocked     = 5,
  OutBlocked    = 6,
  DoubleBlocked = 7
}

export enum FriendStatus
{
  FollowerPendingInFriend = 0,
  Follower                = 1,
  Friend                  = 2,
  Blocked                 = 3,
  DoubleBlocked           = 4
}
