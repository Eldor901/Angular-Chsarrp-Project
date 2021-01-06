import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from '../_services/register.service';
import { HttpClient } from '@angular/common/http';
import { DOMAIN } from '../const/constVariables';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
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

  signIn() {
    // this.registerService.login(this.form).subscribe(next => {
    //   console.log("login in successfuly")
    // }, error => {
    //   console.log('Failed to login')
    // })
    this.http.post(DOMAIN + '/auth/register', this.form.value).subscribe(
      (response) => {
        this._snackBar.open('Registered Successfully please login', 'success', {
          duration: 2000,
          panelClass: ['green-snackbar'],
        });

        this.route.navigate(['/']);
      },
      (error) => {
        this._snackBar.open('Username or Password is incorrect', 'error', {
          duration: 2000,
          panelClass: ['red-snackbar'],
        });
      }
    );
  }
}
