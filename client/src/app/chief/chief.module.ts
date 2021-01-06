import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChiefComponent } from './chief.component';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { AdminComponent } from '../admin/admin.component';
import { ChiefRoutingModule } from './chief-routing.module';

@NgModule({
  declarations: [ChiefComponent, MainPageComponent],
  imports: [
    CommonModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    RouterModule,
    ChiefRoutingModule,
  ],
  providers: [],
  exports: [ChiefComponent],
})
export class ChiefModule {}
