import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { DOMAIN } from '../const/constVariables';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  constructor(private http: HttpClient) {}

  login(form: FormGroup) {
    console.log(form.value);
    return this.http.post(DOMAIN + 'auth/login', form.value).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          sessionStorage.setItem('token', user.token);
        }
      })
    );
  }
}
