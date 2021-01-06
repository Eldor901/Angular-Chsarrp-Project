import { Action } from '@ngrx/store';
import { GetAllUsers } from '../consts';
import { IUsers } from '../Interfaces/users';

export const InitialState: any = {
  Users: Array<IUsers>(),
  loading: false,
  loaded: false,
};

export function userReducer(state: any = InitialState, action: Action) {
  switch (action.type) {
    case GetAllUsers:
      return { ...state, Users: action.payload };
    default:
      return state;
  }
}
