import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout.component';
import { HomeComponent } from './home/home.component';
import { ViewCustomersComponent } from './view-customers/view-customers.component';

const routes: Routes = [
  {path: '', component: AdminLayoutComponent, children:[
    {path: 'home', component: HomeComponent},
    {path: 'view-customers', component: ViewCustomersComponent},
    {path: 'view-product-masters', component: ViewCustomersComponent},
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
