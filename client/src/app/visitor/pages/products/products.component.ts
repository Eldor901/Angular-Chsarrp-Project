import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {GetcontentrequestsService} from '../../../_services/getcontentrequests.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  id: number;
  products;

  constructor(public dialog: MatDialog, private contentService: GetcontentrequestsService, private activateRoute: ActivatedRoute) {
    this.id = activateRoute.snapshot.params['id'];
  }


  fillProducts()
  {
    this.contentService.getProductsByCategory(this.id).subscribe(result => {
      console.warn(result);
      if (result)
      {

        this.products = result;
      }
    })
  }


  ngOnInit(): void {
    this.fillProducts();
  }

}
