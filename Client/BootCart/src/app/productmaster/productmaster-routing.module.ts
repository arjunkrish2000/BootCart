import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { HomeComponent } from './home/home.component';
import { ProductmasterLayoutComponent } from './productmaster-layout.component';

const routes: Routes = [
  {path: '', component: ProductmasterLayoutComponent, children:[
    {path: 'home', component: HomeComponent},
    {path: 'add-product', component: AddProductComponent},
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductmasterRoutingModule { }
