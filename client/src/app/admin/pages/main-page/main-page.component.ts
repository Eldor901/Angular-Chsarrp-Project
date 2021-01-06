import {Component, OnInit} from '@angular/core';
import {Store} from '@ngrx/store';
import {GetAllUsers} from '../../../../redux/consts';
import {GetUsers} from '../../../../redux/actions/user';
import {AdminService} from '../../admin.service';
import {MatDialog} from '@angular/material/dialog';
import {MatSnackBar} from '@angular/material/snack-bar';

interface UserInfo {
  num: number,
  name: string,
  role : Object,
}

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.select.scss','./main-page.component.scss',]
})
export class MainPageComponent implements OnInit {


  constructor(private store: Store<any>, private adminService: AdminService, public dialog: MatDialog,
              private _snackBar: MatSnackBar) { }
  table: object;


  fillTable(word? : string) {
    this.adminService.getAllUser().subscribe((result: [])=>{
      this.table = result;
      console.warn(word);
      if(word) {
        let filterWord = [];
        if (word !== 'NONE') {
          // @ts-ignore
          for (let i: number = 0; i < this.table.length; i++) {
            if (this.table[i].role) {
              if (this.table[i].role.name === word) {
                console.warn(this.table[i]);
                filterWord.push(this.table[i]);
              }
            }
          }

          this.table = filterWord;
        }else
        {
          // @ts-ignore
          this.table = this.table.filter(word => !word.role);
        }
      }
    });
  };


  openDialog(name: string) {
    const dialogRef = this.dialog.open(DialogContentExampleDialog);

    dialogRef.afterClosed().subscribe(result => {
      if(result)
      {
        this.adminService.deleteUser(name).subscribe(result => {
          if(result)
          {
            this._snackBar.open('Deleted Succesfully', 'Delete', {
              duration: 2000,
              panelClass: ['green-snackbar'],
            });
          }
          this.fillTable();
        });
      }
    });
  }

  changeRole(role: string, username: string)
  {
      this.adminService.changeRole(username, role).subscribe(result => {
        if(result)
        {
          this._snackBar.open('Changed Succesfully', 'Role Change', {
            duration: 2000,
            panelClass: ['green-snackbar'],
          });
        }
      }, (err)=>{
        this._snackBar.open('Oops Role is Not changed', 'Role Change', {
          duration: 2000,
          panelClass: ['red-snackbar'],
        });
      })
  }


  ngOnInit(): void {
    this.fillTable();
    this.store.dispatch({type:GetAllUsers,  payload: GetUsers.getUsers()});
  }

}

@Component({
  selector: 'dialog-content-example-dialog',
  template: `
    <mat-dialog-content class="mat-typography">
      <h3>Delete user</h3>
      <p>Do you want to delete user</p>
    </mat-dialog-content>
    <mat-dialog-actions align="end">
      <button mat-button mat-dialog-close [mat-dialog-close]="false">No</button>
      <button mat-button [mat-dialog-close]="true" cdkFocusInitial>Yes</button>
    </mat-dialog-actions>
  `,
})
export class DialogContentExampleDialog  {}

