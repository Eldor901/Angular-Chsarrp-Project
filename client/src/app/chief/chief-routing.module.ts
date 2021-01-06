import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { ChiefComponent } from './chief.component';
import { ChiefGuard } from '../chief.guard';

const routesChief: Routes = [
  {
    path: 'chief',
    component: ChiefComponent,
    canActivate: [ChiefGuard],
    children: [{ path: 'orders', component: MainPageComponent }],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routesChief)],

  exports: [RouterModule],
})
export class ChiefRoutingModule {}
