import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
import { AdminRouting } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import {DialogContentExampleDialog, MainPageComponent} from './pages/main-page/main-page.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import {NzTableModule} from 'ng-zorro-antd/table';
import {ContentComponent, DialogDeleteCusine} from './pages/content/content.component';
import {MatDialogModule} from '@angular/material/dialog';
import {AdminService} from './admin.service';
import {AdminGuard} from '../admin.guard';
import {HTTP_INTERCEPTORS} from '@angular/common/http';
import {MatMenuModule} from '@angular/material/menu';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatFormFieldModule} from '@angular/material/form-field';
import { DialogComponent } from './pages/content/dialog/dialog.component';
import {MatInputModule} from '@angular/material/input';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {DialogDeleteProduct, ProductsComponent} from './pages/products/products.component';
import {DialogComponentProduct} from './pages/products/dialog/dialog.component';
import {DialogProductComment} from './pages/products/dialogComment/dialog.component';

@NgModule({
  declarations: [AdminComponent, MainPageComponent, ContentComponent, DialogContentExampleDialog, DialogComponent,
    ProductsComponent,  DialogComponentProduct, DialogProductComment, DialogDeleteCusine, DialogDeleteProduct],
  imports: [
    CommonModule,
    BrowserModule,
    AdminRouting,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    RouterModule,
    MatCardModule,
    MatDialogModule,
    MatMenuModule,
    MatGridListModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AdminService, AdminGuard, {
    provide: HTTP_INTERCEPTORS,
    useClass: AdminGuard,
    multi: true,
  },
  ],
  exports: [AdminComponent],
})
export class AdminModule {}
