import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductSpecificationComponent } from './add-product-specification/add-product-specification.component';
import { AddProductComponent } from './add-product/add-product.component';
import { HomeComponent } from './home/home.component';
import { ProductmasterLayoutComponent } from './productmaster-layout.component';

const routes: Routes = [
  {path: '', component: ProductmasterLayoutComponent, children:[
    {path: '', component: HomeComponent},
    {path: 'home', component: HomeComponent},
    {path: 'add-product', component: AddProductComponent},
    {path: 'add-product-specification/:id', component: AddProductSpecificationComponent},

  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductmasterRoutingModule { }
