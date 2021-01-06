import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WaiterComponent } from './waiter.component';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { WaiterGuard } from '../waiter.guard';

const routesVisitor: Routes = [
  {
    path: 'waiter',
    component: WaiterComponent,
    canActivate: [WaiterGuard],
    children: [{ path: 'orders', component: MainPageComponent }],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routesVisitor)],
  exports: [RouterModule],
})
export class WaiterRoutingModule {}
