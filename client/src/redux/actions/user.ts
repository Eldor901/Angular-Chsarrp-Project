import { Action } from '@ngrx/store';
import { GetAllUsers } from '../consts';
import { IUsers } from '../Interfaces/users';

export class GetUsers implements Action {
  type: string = GetAllUsers;
  constructor(public payload: boolean) {
    this.payload = true;
  }

  public static getUsers() {
    return true;
  }
}
