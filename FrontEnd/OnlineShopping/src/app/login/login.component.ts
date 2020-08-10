import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { LoginServiceService } from '../Services/login-service.service';
import { CustomerServiceService } from '../Services/customer-service.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { NotificationService } from '../Services/notification-service.service';
import { DataService } from '../Services/data.service';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

 // @Output() demo = new EventEmitter<string>();

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  passwordFormControl = new FormControl('', [
    Validators.required
  ]);

  matcher = new MyErrorStateMatcher();

  emailTxt: any;
  passwordTxt: any;
  token: any = [];
  customerDetails: any;
  isLoged: any = 'false';
  customers: any = [];

  status: any;

  constructor(private loginService: LoginServiceService,
              private customerSrvice: CustomerServiceService,
              private cookieService: CookieService,
              private router: Router,
              private notifyService: NotificationService,
              private dataService: DataService) {}

  ngOnInit(): void {
  }

  onLogin(form: NgForm) {
    this.onSetToken(this.emailTxt, this.passwordTxt);
  }


  onSetToken(email: any, password: any) {
    this.loginService.loginCustomer(email, password).subscribe((data: []) => {
        this.token = data;
       // this.cookieService.set('Token', this.token.token.result);
        this.cookieService.set('Token', this.token.token);

        if (this.token.token != null) {

          this.customerSrvice.getCustomer(email).subscribe((data2: []) => {
            this.customerDetails = data2;
            console.log(this.customerDetails);
            this.isLoged = 'true';
            this.cookieService.set('Loged', this.isLoged);
            this.cookieService.set('fullName', this.customerDetails.fName + ' ' + this.customerDetails.lName);
            this.cookieService.set('Email', email);
            this.router.navigate(['products']);
            this.notifyService.showSuccess(`Welcome ${this.customerDetails.fName}`, 'Login Successfull');
            this.dataService.callNavBar();
          });
        }
      }, error => {
        console.log(error);
        this.notifyService.showError(`Invalid user name or password`, 'Login Error');
      });
   }

}
