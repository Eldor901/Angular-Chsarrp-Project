import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { DOMAIN } from '../const/constVariables';
import {Observable, throwError} from 'rxjs';
import {catchError} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) {
  }

  getAllUser()
  {
    return this.http.get(DOMAIN + '/user/users')
  }

  deleteUser(name: string)
  {
    return this.http.post(DOMAIN + '/user/deleteUser', {
      username: name
    }).pipe(catchError(this.handleError))
  }

  changeRole(username: string, role: string)
  {
    return this.http.post(DOMAIN + '/user/changerole', {
      username: username,
      role: role
    }).pipe(catchError(this.handleError))
  }

  addCuisine(fd: FormData)
  {
    return this.http.post(DOMAIN + '/actions/addcusine', fd
    ).pipe(catchError(this.handleError))
  }

  addProduct(fd: FormData)
  {
    return this.http.post(DOMAIN + '/actions/addproduct', fd
    ).pipe(catchError(this.handleError))
  }

  addProductCategory(category: string)
  {
    return this.http.post(DOMAIN + '/actions/addproductcategory', {
      name: category
    }
    ).pipe(catchError(this.handleError))
  }


  deleteCusine(id: number)
  {
    return this.http.put(DOMAIN + `/actions/deleteCusine/${id}`, {}).pipe(catchError(this.handleError))
  }

  deleteProduct(id: number)
  {
    return this.http.put(DOMAIN + `/actions/deleteProduct/${id}`, {}).pipe(catchError(this.handleError))
  }


  handleError(error)
  {
    return throwError('Server Error');
  }
}
