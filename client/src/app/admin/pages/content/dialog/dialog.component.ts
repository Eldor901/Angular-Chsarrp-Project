import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AdminService} from '../../../admin.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {

  form:  FormGroup;
  selectedFile = null;
  imgURL: any;
  public imagePath;


  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private adminService: AdminService, private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', [
        Validators.required
      ]),
      file: new FormControl('', Validators.required),
      desc: new FormControl('', Validators.required)
    })
  }

  onNoClick() {
    this.dialogRef.close();
  }


  onSubmit() {
    const formData = {...this.form.value};
    const fd: FormData = new FormData();

    fd.append('name', formData.name);
    fd.append('imgurl', this.selectedFile);
    fd.append('desc', formData.desc);

    this.adminService.addCuisine(fd).subscribe(result => {
      if(result)
      {
        this._snackBar.open('Cuisine uploaded  Succesfully', 'Delete', {
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
