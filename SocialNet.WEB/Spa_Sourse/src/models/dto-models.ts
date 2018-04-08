import { UserRelation } from './dto-enums';

export class User
{
  public Email: string;
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
  public login: string;
}

