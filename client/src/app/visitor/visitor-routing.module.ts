import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { VisitorComponent } from './visitor.component';
import { AdminGuard } from '../admin.guard';
import { VisitorGuard } from '../visitor.guard';
import {CreateProductComponent} from './pages/create-product/create-product.component';
import {ProductsComponent} from './pages/products/products.component';

const routesVisitor: Routes = [
  {
    path: 'visitor',
    component: VisitorComponent,
    canActivate: [VisitorGuard],
    children: [
      { path: 'showcousine', component: MainPageComponent },
      { path: 'createProduct', component: CreateProductComponent},
      { path: 'products/:id', component: ProductsComponent},
      ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routesVisitor)],
  exports: [RouterModule],
})
export class VisitorRoutingModule {}
