import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {GetcontentrequestsService} from '../../../_services/getcontentrequests.service';
import {ActivatedRoute} from '@angular/router';
import {DialogComponentProduct} from './dialog/dialog.component';
import {DialogProductComment} from './dialogComment/dialog.component';
import {DialogContentExampleDialog} from '../main-page/main-page.component';
import {AdminService} from '../../admin.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  id: number;
  products;

  constructor(public dialog: MatDialog, private contentService: GetcontentrequestsService, private activateRoute: ActivatedRoute,  private adminService: AdminService,private _snackBar: MatSnackBar) {
    this.id = activateRoute.snapshot.params['id'];
  }


  fillProducts()
  {
    this.contentService.getProductsByCategory(this.id).subscribe(result => {
      if (result)
      {

        this.products = result;
      }
    })
  }


  ngOnInit(): void {
    this.fillProducts();
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponentProduct, {
      width: '400px',
      data: this.id,
    });

    dialogRef.afterClosed().subscribe(result => {
      this.fillProducts();
    });
  }

  openDialogComment(): void {
    const dialogRef = this.dialog.open(DialogProductComment, {
      width: '400px',
      data: this.id,
    });
  }

  deleteProductDialog(id: any) {
    const dialogRef = this.dialog.open(DialogDeleteProduct);

    dialogRef.afterClosed().subscribe(result => {
      if(result)
      {
        this.adminService.deleteProduct(id).subscribe(result => {
          if(result)
          {
            this._snackBar.open('Deleted Succesfully', 'Delete', {
              duration: 2000,
              panelClass: ['green-snackbar'],
            });
          }
          this.fillProducts();
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
export class DialogDeleteProduct  {}

