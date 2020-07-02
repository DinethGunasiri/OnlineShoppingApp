import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators, FormGroup, FormBuilder} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { NotificationService } from '../Services/notification-service.service';
import { CustomerServiceService } from '../Services/customer-service.service';
import { Router } from '@angular/router';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

interface Gender {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.scss']
})
export class CustomerRegistrationComponent implements OnInit {

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  inputControl = new FormControl('', [
    Validators.required,
  ]);

  passwordControl = new FormControl('', [
    Validators.required
  ]);

  matcher = new MyErrorStateMatcher();

  genders: Gender[] = [
    {value: 'Male', viewValue: 'Male'},
    {value: 'Female', viewValue: 'Female'}
  ];

  fNameTxt: any;
  lNameTxt: any;
  genderSelect: any;
  birthDate: any;
  emailTxt: any;
  telephoneTxt: any;
  passwordTxt: any;
  conPasswordTxt: any;
  addressTxt1: any;
  streetTxt: any;
  cityTxt: any;
  stateTxt: any;
  postalCodeTxt: number;
  createForm: FormGroup;
  fullAddress: any;
  fullName: any;


  constructor(private notifyService: NotificationService,
              private customerService: CustomerServiceService,
              private router: Router) {
   }

  ngOnInit(): void {
  }

  onClickSave(form: NgForm) {
    if (this.passwordTxt != this.conPasswordTxt) {
      this.notifyService.showError('Passwords are not matching', 'Password Error');
    }
    else {
      this.fullAddress = this.addressTxt1 + ', ' + this.streetTxt + ', ' + this.cityTxt + ', ' + this.stateTxt;
      console.log(this.fullAddress);
      this.fullName = this.fNameTxt + ' ' + this.lNameTxt;
      console.log(this.fullName);
      this.customerService.postCustomer
      (this.emailTxt, this.fullName, this.birthDate,
        this.genderSelect, this.fullAddress, this.postalCodeTxt, this.telephoneTxt, this.passwordTxt).subscribe((data) => {
        console.log(data);
      });
      this.router.navigate(['products']);
      this.notifyService.showSuccess('Successfully registered, please log in', 'Registration successful');
    }
  }
}
