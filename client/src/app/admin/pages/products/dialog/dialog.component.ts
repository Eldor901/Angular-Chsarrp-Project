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
export class DialogComponentProduct implements OnInit {
  productCategories;
  form:  FormGroup;
  selectedFile = null;
  imgURL: any;
  public imagePath;



  constructor(
    public dialogRef: MatDialogRef<DialogComponentProduct>,
    @Inject(MAT_DIALOG_DATA) public data: any, private adminService: AdminService, private _snackBar: MatSnackBar, private contentService: GetcontentrequestsService) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', [
        Validators.required
      ]),
      file: new FormControl('', Validators.required),
      price: new FormControl('', [Validators.required]),
      category: new FormControl('', [Validators.required])
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

    const fd: FormData = new FormData();

    fd.append('name', formData.name);
    fd.append('imgUrl', this.selectedFile);
    fd.append('price', formData.price);
    fd.append('productCategoryName', formData.category);
    fd.append('cousineName', this.data);

    this.adminService.addProduct(fd).subscribe(result => {
      if(result)
      {
        this._snackBar.open('Product uploaded Succesfully', 'Delete', {
          duration: 2000,
          panelClass: ['green-snackbar'],
        });
      }
    });

    this.dialogRef.close();
  }

  onFileSelected(event) {
    this.selectedFile = event.target.files[0];

    var reader = new FileReader();
    this.imagePath = event.target.files;
    reader.readAsDataURL(event.target.files[0]);
    reader.onload = (_event) => {
      this.imgURL = reader.result;
    }
  }

}
