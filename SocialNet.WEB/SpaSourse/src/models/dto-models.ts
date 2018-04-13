import { UserRelation } from './dto-enums';

export class User
{
  public email: string;
  public password: string;
  public id: number;
  public firstName: string;
  public lastName: string;
  public fullName: string;
  public dateOfBirth: string;
  public city: string;
  public relationType: UserRelation;
}

export class Authentication
{
  public id: number;
  public email: string;
}

export class Avatar
{
    public id: number;
    public path: string;
    public active: boolean;
    public userId: number;
    public fullPath: string;
}

