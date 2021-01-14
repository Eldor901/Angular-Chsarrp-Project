import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AdminService} from '../../../admin.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {GetcontentrequestsService} from '../../../../_services/getcontentrequests.service';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogProductComment implements OnInit {
  productCategories;
  form:  FormGroup;
  selectedFile = null;


  constructor(
    public dialogRef: MatDialogRef<DialogProductComment>,
    @Inject(MAT_DIALOG_DATA) public data: any, private adminService: AdminService, private _snackBar: MatSnackBar, private contentService: GetcontentrequestsService) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', [
        Validators.required
      ]),
    });

    this.fillProductCategory()
  }

  fillProductCategory()
  {
    this.contentService.getProductCategories().subscribe(result => {
      if (result)
      {
        this.productCategories = result;
      }
    })
  }

  onNoClick() {
    this.dialogRef.close();
  }


  onSubmit() {
    const formData = {...this.form.value};

    this.adminService.addProductCategory(formData.name).subscribe(result => {
      if(result)
      {
        this._snackBar.open('Product Category Added Successfully', 'Delete', {
          duration: 2000,
          panelClass: ['green-snackbar'],
        });
      }
    });

    this.dialogRef.close();
  }

  onFileSelected(event) {
    this.selectedFile = event.target.files[0];
  }

}
