import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from '@angular/material/dialog';
import {DialogComponent} from './dialog/dialog.component';
import {GetcontentrequestsService} from '../../../_services/getcontentrequests.service';
import {Router} from '@angular/router';
import {AdminService} from '../../admin.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {DialogContentExampleDialog} from '../main-page/main-page.component';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent implements OnInit {

  contentCus: object;

  constructor(public dialog: MatDialog, private contentService: GetcontentrequestsService, private router: Router,  private adminService: AdminService,private _snackBar: MatSnackBar) { }

  fillCuis()
  {
    this.contentService.getAllCusines().subscribe(result => {
      if (result)
      {
        this.contentCus = result;
      }
    })
  }

  ngOnInit(): void {
    this.fillCuis();

  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '400px',
      data: this.fillCuis(),
    });

    dialogRef.afterClosed().subscribe(result => {
      this.fillCuis();
    });
  }

  goToProducts(id: any) {
    console.warn(this.router);
    this.router.navigate([`admin/products`, id]);
  }

  deleteCusineDialog(id: any) {
    const dialogRef = this.dialog.open(DialogContentExampleDialog);

    dialogRef.afterClosed().subscribe(result => {
      if(result)
      {
        this.adminService.deleteCusine(id).subscribe(result => {
          if(result)
          {
            this._snackBar.open('Deleted Succesfully', 'Delete', {
              duration: 2000,
              panelClass: ['green-snackbar'],
            });
          }
          this.fillCuis();
        });
      }
    });
  }
}

@Component({
  selector: 'dialog-content-example-dialog',
  template: `
    <mat-dialog-content class="mat-typography">
      <h3>Delete user</h3>
      <p>Do you want to delete Cusine</p>
    </mat-dialog-content>
    <mat-dialog-actions align="end">
      <button mat-button mat-dialog-close [mat-dialog-close]="false">No</button>
      <button mat-button [mat-dialog-close]="true" cdkFocusInitial>Yes</button>
    </mat-dialog-actions>
  `,
})
export class DialogDeleteCusine  {}





