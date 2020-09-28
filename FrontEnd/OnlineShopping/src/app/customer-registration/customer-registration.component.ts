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
  ngForm: FormGroup;
  fullAddress: any;
  fullName: any;

  testEmail: any;


  constructor(private notifyService: NotificationService,
              private customerService: CustomerServiceService,
              private formBuilder: FormBuilder,
              private router: Router) {
                this.createForm = formBuilder.group({
                  fNameTxt: ['', Validators.required],
                  lNameTxt: ['', Validators.required],
                  genderSelect: ['', Validators.required],
                  birthDate: ['', Validators.required],
                  emailTxt: ['', Validators.required],
                  telephoneTxt: ['', Validators.required],
                  passwordTxt: ['', Validators.required],
                  conPasswordTxt: ['', Validators.required],
                  addressTxt1: ['', Validators.required],
                  streetTxt: ['', Validators.required],
                  cityTxt: ['', Validators.required],
                  stateTxt: ['', Validators.required],
                  postalCodeTxt: ['', Validators.required]
                });
              }

  ngOnInit(): void {
  }

  // Register new user
  onClickSave() {

    // Get input from user
    this.fNameTxt = this.createForm.get('fNameTxt').value;
    this.lNameTxt = this.createForm.get('lNameTxt').value;
    this.genderSelect = this.createForm.get('genderSelect').value;
    this.birthDate = this.createForm.get('birthDate').value;
    this.emailTxt = this.createForm.get('emailTxt').value;
    this.telephoneTxt = this.createForm.get('telephoneTxt').value;
    this.passwordTxt = this.createForm.get('passwordTxt').value;
    this.conPasswordTxt = this.createForm.get('conPasswordTxt').value;
    this.addressTxt1 = this.createForm.get('addressTxt1').value;
    this.streetTxt = this.createForm.get('streetTxt').value;
    this.cityTxt = this.createForm.get('cityTxt').value;
    this.stateTxt = this.createForm.get('stateTxt').value;
    this.postalCodeTxt = this.createForm.get('postalCodeTxt').value;

    // Check whether passwords are matching
    if (this.passwordTxt != this.conPasswordTxt) {
        this.notifyService.showError('Passwords are not matching', 'Password Error');
      }
      else { // Check email all ready exsists in database
       this.customerService.getCustomer(this.emailTxt).subscribe((data) => {
        console.log(data);
        if (data) {
          this.notifyService.showError('Email already exsists, please log in', 'Password Error');
        }
       }, error => {
        this.customerService.postCustomer
        (this.emailTxt, this.fNameTxt, this.lNameTxt, this.birthDate,
          this.genderSelect, this.addressTxt1, this.streetTxt,
          this.cityTxt, this.stateTxt , this.postalCodeTxt, this.telephoneTxt, this.passwordTxt).subscribe((data) => {
            
            // if data add successfully navigate back to home page
            this.router.navigate(['products']);

            // success message
            this.notifyService.showSuccess('Successfully registered, please log in', 'Registration successful');
        }, error => { // registration error message
          this.notifyService.showError('Error', 'Registration Error');
        });
       });
      }
  }
}
