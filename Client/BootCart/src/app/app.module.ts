import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { PublicModule } from './public/public.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { CustomerModule } from './customer/customer.module';
import { AdminModule } from './admin/admin.module';
import { ProductmasterModule } from './productmaster/productmaster.module';
import { CookieService } from 'ngx-cookie-service';
import { ErrorInterceptor } from './helpers/interceptors/errorInterceptor';
import { JwtInterceptor } from './helpers/interceptors/jwtInterceptor';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PublicModule,
    FormsModule,
    AuthModule,
    HttpClientModule,
    CustomerModule,
     AdminModule,
    ProductmasterModule
  ],
  providers: [CookieService, [
    {
      provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true 
    },
    { 
      provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true
    }
  ]],
  bootstrap: [AppComponent]
})
export class AppModule { }
