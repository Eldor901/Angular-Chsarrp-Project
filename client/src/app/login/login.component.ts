import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from '../_services/register.service';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DOMAIN, Roles } from '../const/constVariables';
import { Router } from '@angular/router';

export interface Login {
  token: string;
  role: Roles;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(
    private registerService: RegisterService,
    private http: HttpClient,
    private _snackBar: MatSnackBar,
    private route: Router
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      username: new FormControl(''),
      password: new FormControl('', [Validators.minLength(6)]),
    });
  }

  login() {
    this.http.post<Login>(DOMAIN + '/auth/login', this.form.value).subscribe(
      (response) => {
        if (response) {
          sessionStorage.setItem('token', response.token);
          sessionStorage.setItem('role', response.role.toString());

          console.log(response.role === Roles.CHIEF);

          switch (response.role) {
            case Roles.ADMIN:
              this.route.navigate(['/admin/main']);
              break;
            case Roles.VISITOR:
              this.route.navigate(['/visitor/showcousine']);
              break;
            case Roles.CHIEF:
              this.route.navigate(['/chief/orders']);
              break;
            case Roles.WAITER:
              this.route.navigate(['/waiter/orders']);
              break;
            default:
              this._snackBar.open(
                'You dont have permission to enter yet',
                'error',
                {
                  duration: 2000,
                  panelClass: ['red-snackbar'],
                }
              );
              break;
          }

          // response.role ===  Roles.ADMIN  ? this.route.navigate(['/admin/main'])
          //   : Roles.VISITOR  ? this.route.navigate(['/visitor/showcousine'])
          //   : Roles.CHIEF ? console.log(Roles.CHIEF)
          //     : Roles.WAITER ? this.route.navigate(['/waiter/orders'])
          //       : this._snackBar.open("You dont have permission to enter yet", "error", {
          //         duration: 2000,
          //         panelClass: ['red-snackbar'],
          //       });
        }
      },
      (error) => {
        this._snackBar.open('Login or password is incorrect', 'error', {
          duration: 2000,
          panelClass: ['red-snackbar'],
        });
      }
    );
  }
}
