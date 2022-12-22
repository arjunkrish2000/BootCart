import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { HomeComponent } from './home/home.component';
import { CustomerLayoutComponent } from './customer-layout.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { RouterModule } from '@angular/router';
import { CustomerNavbarComponent } from './customer-navbar/customer-navbar.component';
import { ViewBagComponent } from './view-bag/view-bag.component';
import { ViewProductsComponent } from './view-products/view-products.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { PublicModule } from '../public/public.module';
import { ProfileComponent } from './profile/profile.component';


@NgModule({
  declarations: [
    HomeComponent,
    CustomerLayoutComponent,
    WishlistComponent,
    CustomerNavbarComponent,
    ViewBagComponent,
    ViewProductsComponent,
    OrderHistoryComponent,
    InvoiceComponent,
    ProfileComponent,
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    RouterModule,
    PublicModule
  ]
})
export class CustomerModule { }
