import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {

  form:  FormGroup;


  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {}

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

  onYesClick()
  {
    this.dialogRef.close();
  }

  onSubmit() {
    const formData = {...this.form.value};
    console.warn(formData);
  }
}
