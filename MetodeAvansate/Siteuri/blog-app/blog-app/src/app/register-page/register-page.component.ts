import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { User } from '../models/user';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent {

  MatchingValidator: ValidatorFn = (form: AbstractControl): ValidationErrors | null => {
    return (formGroup: FormGroup) => {
      const control = form.get("password");
      const matchingControl = form.get("confirmPassword");
      
      if(control && matchingControl && control.value != matchingControl.value) {
          return { passwordmatcherror: true };
      }
      return null;
    };
  }

  passwordValidator: ValidatorFn = ( control: AbstractControl ): ValidationErrors | null => {
      const password = control.value;
      const hasLower = /[a-z]/.test(password);
      const hasUpper = /[A-Z]/.test(password);
      const hasNumber = /\d/.test(password);
      //const hasSymbol = '!@#$%^&*()-_=+'.
      
      const isValid = hasLower && hasUpper && hasNumber;
      if (!isValid) {
          return {
              lower: !hasLower,
              upper: !hasUpper,
              number: !hasNumber
          }
      }
      return null;
  };
  
  form: FormGroup = new FormGroup({
    firstName: new FormControl<string>('', [Validators.required]),
    lastName: new FormControl<string>('', [Validators.required]),
    nickName: new FormControl<string>('', [Validators.required]),
    email: new FormControl<string>('', [Validators.required, Validators.email]),
    phone: new FormControl<string>('', [Validators.required]),
    password: new FormControl<string>('', [Validators.required, Validators.minLength(8), this.passwordValidator]),
    confirmPassword: new FormControl<string>('', [Validators.required])
  }, [this.MatchingValidator]);

  constructor(private userService: UsersService) { }

  onSubmit() {
    if(this.form.valid) {
      let user: User = {
        firstName: this.form.controls['firstName'].value,
        lastName: this.form.controls['lastName'].value,
        nickName: this.form.controls['nickName'].value,
        email: this.form.controls['email'].value,
        phone: this.form.controls['phone'].value,
        password: this.form.controls['password'].value,
      } as User;
  
      this.userService.postUser(user).subscribe(res => {
        console.log(res);
      });
    } else {
      console.log(this.form.errors);
    }
  }
}
