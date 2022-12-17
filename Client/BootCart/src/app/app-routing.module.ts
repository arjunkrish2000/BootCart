import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  
    {
      path: '', loadChildren: () => import('./public/public-routing.module').then(m => m.PublicRoutingModule)
    },
    {
      path: 'auth', loadChildren: () => import('./auth/auth-routing.module').then(m => m.AuthRoutingModule)
    },
    {
      path: 'admin', loadChildren: () => import('./admin/admin-routing.module').then(m => m.AdminRoutingModule)
    },
    {
      path: 'customer', loadChildren: () => import('./customer/customer-routing.module').then(m => m.CustomerRoutingModule)
    },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
