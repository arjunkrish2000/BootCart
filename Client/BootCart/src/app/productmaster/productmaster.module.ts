import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductmasterRoutingModule } from './productmaster-routing.module';
import { HomeComponent } from './home/home.component';
import { ProductmasterLayoutComponent } from './productmaster-layout.component';
import { ProductmasterNavbarComponent } from './productmaster-navbar/productmaster-navbar.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    HomeComponent,
    ProductmasterLayoutComponent,
    ProductmasterNavbarComponent,
  ],
  imports: [
    CommonModule,
    ProductmasterRoutingModule,
    RouterModule
  ]
})
export class ProductmasterModule { }
