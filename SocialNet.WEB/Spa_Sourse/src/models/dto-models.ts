import { UserRelationType } from './dto-enums';

export class User
{
  public Email: string;
  public password: string;
  public id: number;
  public firstName: string;
  public lastName: string;
  public dateOfBirth: string;
  public city: string;
  public relationType: UserRelationType;
}

export class Authentication
{
  public id: number;
  public login: string;
}

