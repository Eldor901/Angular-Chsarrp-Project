import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {GetcontentrequestsService} from '../../../_services/getcontentrequests.service';
import {Router} from '@angular/router';
import {DialogComponent} from '../../../admin/pages/content/dialog/dialog.component';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss'],
})
export class MainPageComponent implements OnInit {
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


  goToProducts(id: any) {
    this.router.navigate([`visitor/products`, id]);
  }
}
