import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { LoginServiceService } from '../login-service.service';
import { CustomerServiceService } from '../customer-service.service';
import { CookieService } from 'ngx-cookie-service';

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

  constructor(private loginService: LoginServiceService,
              private customerSrvice: CustomerServiceService,
              private cookieService: CookieService) { }

  ngOnInit(): void {
  }

  onLogin(form: NgForm) {

    this.onGetCustomer(this.emailTxt, this.passwordTxt);
    this.onSetToken(this.emailTxt, this.passwordTxt);
  }

  onGetCustomer(email: any, password: any) {
    console.log(email);
    this.customerSrvice.getCustomer(email).subscribe((data: []) => {
      this.customerDetails = data;
      this.dbEmail = this.customerDetails.email;
      this.dbPassword = this.customerDetails.password;

      if (password == this.dbPassword && email == this.dbEmail)
      {
        console.log(this.dbEmail);
        console.log(this.emailTxt);
        console.log(this.passwordTxt);
        console.log(this.dbPassword);
      }
      else {
        console.log('Invalid user');
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
            console.log(this.customerDetails2);
          });
        }
      });
   }

}
