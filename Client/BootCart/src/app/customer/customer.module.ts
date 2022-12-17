import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { HomeComponent } from './home/home.component';
import { CustomerLayoutComponent } from './customer-layout.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { RouterModule } from '@angular/router';
import { CustomerNavbarComponent } from './customer-navbar/customer-navbar.component';


@NgModule({
  declarations: [
    HomeComponent,
    CustomerLayoutComponent,
    WishlistComponent,
    CustomerNavbarComponent,
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    RouterModule,
  ]
})
export class CustomerModule { }
