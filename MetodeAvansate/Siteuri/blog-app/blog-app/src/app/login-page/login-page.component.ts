import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../services/login.service';
import { UserLogin } from '../models/userLogin';
import { Token } from '../models/token';
import { GlobalService } from '../services/global.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent {

  form: FormGroup = new FormGroup({
    email: new FormControl<string>('', [Validators.required, Validators.email]),
    password: new FormControl<string>('', [Validators.required, Validators.minLength(8)]),
  });

  constructor(private loginService: LoginService,
    private service: GlobalService,
    private router: Router) { }
  
  login() {
    if(this.form.valid) {
      let userLogin: UserLogin = {
        email: this.form.controls['email'].value,
        password: this.form.controls['password'].value,
      }

      this.loginService.login(userLogin).subscribe((res: Token) => {
        localStorage.setItem("token", res.token)
      })
      this.service.setLogIn(true);
      this.router.navigate(['/']);
    }
  }
}
