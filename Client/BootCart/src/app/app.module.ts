import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { PublicModule } from './public/public.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PublicModule,
    FormsModule,
    AuthModule,
    RouterModule.forRoot([
      {
        path: '', loadChildren: () => import('./public/public-routing.module').then(m => m.PublicRoutingModule)
      },
      {
        path: 'auth', loadChildren: () => import('./auth/auth-routing.module').then(m => m.AuthRoutingModule)
      },
     
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
