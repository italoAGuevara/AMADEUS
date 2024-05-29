import { Routes } from '@angular/router';
import {SinginComponent} from "./modules/authorization/singin/singin.component";
import {HomeComponent} from "./modules/dashboard/home/home.component";
import {sessionGuard} from "./core/guards/session.guard";


export const routes: Routes = [
  {
    path: '',
    component : HomeComponent,
    loadChildren : () => import('./modules/dashboard/dashboard-routing.module').then(m => m.DashboardRoutingModule),
    //canActivate : [sessionGuard]
  },
  {
    path: 'auth',
    component : SinginComponent
  },
  {
    path : '**',
    redirectTo : ''
  }
];
