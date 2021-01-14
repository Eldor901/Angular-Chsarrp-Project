import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { AdminComponent } from './admin.component';
import { AdminGuard } from '../admin.guard';
import {ContentComponent} from './pages/content/content.component';
import {HTTP_INTERCEPTORS} from '@angular/common/http';
import {ProductsComponent} from './pages/products/products.component';

const routesAdmin: Routes = [
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AdminGuard],
    children: [
      { path: 'main', component: MainPageComponent },
      { path: 'content', component: ContentComponent },
      { path: 'products/:id', component: ProductsComponent},
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routesAdmin)],
  exports: [RouterModule],
})
export class AdminRouting {}
