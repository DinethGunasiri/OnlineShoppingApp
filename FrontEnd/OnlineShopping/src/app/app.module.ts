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
import {AuthInterceptorService} from './Services/auth-iterceptor.service';
import {CookieService} from 'ngx-cookie-service';
import {NotifierModule} from 'angular-notifier';
import {ToastrModule} from 'ngx-toastr';
import {DataService} from './Services/data.service';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatStepperModule} from '@angular/material/stepper';
import {MatTableModule} from '@angular/material/table';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatDividerModule} from '@angular/material/divider';
import {OrderHistoryComponent} from '../app/order-history/order-history.component';
import {MatRadioModule} from '@angular/material/radio';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CustomerRegistrationComponent,
    ProductsComponent,
    NavBarComponent,
    ShoppingCartComponent,
    OrderHistoryComponent
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
    ReactiveFormsModule,
    NotifierModule,
    ToastrModule.forRoot(),
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatGridListModule,
    MatStepperModule,
    MatTableModule,
    MatExpansionModule,
    MatDividerModule,
    MatRadioModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    },
    CookieService,
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
