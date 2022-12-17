import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { HomeComponent } from './home/home.component';
import { CustomerLayoutComponent } from './customer-layout.component';
import { WishlistComponent } from './wishlist/wishlist.component';


@NgModule({
  declarations: [
    HomeComponent,
    CustomerLayoutComponent,
    WishlistComponent
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule
  ]
})
export class CustomerModule { }
