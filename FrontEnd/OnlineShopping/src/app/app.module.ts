import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { CustomerRegistrationComponent } from './customer-registration/customer-registration.component';
import { ProductsComponent } from './products/products.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NavbarModule, WavesModule, ButtonsModule, MDBBootstrapModule  } from 'angular-bootstrap-md';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatInputModule} from '@angular/material/input';
import {MatBadgeModule} from '@angular/material/badge';
import {MatIconModule} from '@angular/material/icon';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import {MatCardModule} from '@angular/material/card';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AuthInterceptorService} from './auth-interceptor.service';
import {CookieService} from 'ngx-cookie-service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CustomerRegistrationComponent,
    ProductsComponent,
    NavBarComponent,
    ShoppingCartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NavbarModule,
    WavesModule,
    ButtonsModule,
    MDBBootstrapModule.forRoot(),
    MatMenuModule,
    MatButtonModule,
    MatToolbarModule,
    MatInputModule,
    MatBadgeModule,
    MatIconModule,
    MatCardModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    },
    CookieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
