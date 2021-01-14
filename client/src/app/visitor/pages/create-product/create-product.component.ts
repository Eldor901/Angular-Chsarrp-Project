import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {GetcontentrequestsService} from '../../../_services/getcontentrequests.service';
import {Router} from '@angular/router';
import {DialogComponent} from '../../../admin/pages/content/dialog/dialog.component';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss']
})
export class CreateProductComponent implements OnInit {
  contentCus: object;

  constructor(public dialog: MatDialog, private contentService: GetcontentrequestsService, private router: Router) { }

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

}
