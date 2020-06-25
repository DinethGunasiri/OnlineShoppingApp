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

  @Output() demo = new EventEmitter<string>();
  
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
  dbEmail: any;
  dbPassword: any;
  passwordEncript: any;
  token: any = [];
  customerDetails: any = [];
  customerDetails2: any = [];
  isLoged: any = 'false';

  constructor(private loginService: LoginServiceService,
              private customerSrvice: CustomerServiceService,
              private cookieService: CookieService,
              private router: Router,
              private notifyService: NotificationService,
              private dataService: DataService) {}

  ngOnInit(): void {
  }

  onLogin(form: NgForm) {
    
    this.onGetCustomer(this.emailTxt, this.passwordTxt);
    this.onSetToken(this.emailTxt, this.passwordTxt);
    this.onCheckCustomer();
  }

  onGetCustomer(email: any, password: any) {
    console.log(email);

    this.customerSrvice.getCustomer(email).subscribe((data = []) => {
          this.customerDetails = data;

          this.dbEmail = this.customerDetails.email;
          this.dbPassword = this.customerDetails.password;

          if (password == this.dbPassword && email == this.dbEmail)
              {
                this.isLoged = 'true';
                this.cookieService.set('Loged', this.isLoged);
                this.cookieService.set('fullName', this.customerDetails.fullName);
                this.router.navigate(['products']);
                this.notifyService.showSuccess(`Welcome ${this.customerDetails.fullName}`, 'Login Successfull');
                this.dataService.callNavBar();
              }
              else {
                this.notifyService.showError(`Invalid user name or password`, 'Login Error');
                return;
              }

      });
  }

  onSetToken(email: any, password: any) {
    this.loginService.loginCustomer(email, password).subscribe((data: []) => {
        this.token = data;
        this.cookieService.set('Token', this.token.token.result);
       // sessionStorage.setItem('Token', this.token.token.result);

        if (this.token.token.result != null) {
          this.customerSrvice.getCustomers().subscribe((data2: []) => {
            this.customerDetails2 = data2;
          });
        }
      });
   }

   onCheckCustomer() {
    if (this.customerDetails.length == 0) {
      this.notifyService.showError(`Invalid user name`, 'Login Error');
      return;
    }
   }

}
