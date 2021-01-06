import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { VisitorComponent } from './visitor.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { VisitorRoutingModule } from './visitor-routing.module';
import { MatButtonModule } from '@angular/material/button';
import { BrowserModule } from '@angular/platform-browser';
import { AdminRouting } from '../admin/admin-routing.module';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [MainPageComponent, VisitorComponent],
  imports: [
    CommonModule,
    MatSidenavModule,
    BrowserModule,
    MatToolbarModule,
    MatIconModule,
    RouterModule,
    VisitorRoutingModule,
    MatButtonModule,
    MatCardModule,
  ],
})
export class VisitorModule {}
