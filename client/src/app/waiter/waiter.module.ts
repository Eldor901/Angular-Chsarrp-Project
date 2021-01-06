import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WaiterComponent } from './waiter.component';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { WaiterRoutingModule } from './waiter-routing.modules';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  declarations: [WaiterComponent, MainPageComponent],
  imports: [
    CommonModule,
    WaiterRoutingModule,
    MatSidenavModule,
    MatToolbarModule,
  ],
})
export class WaiterModule {}
