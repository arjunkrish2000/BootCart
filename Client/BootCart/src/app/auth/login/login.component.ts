import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
	message: string = '';
	constructor(private loginService:AuthService, private router:Router) { }

	checkLogin(form: NgForm){
		this.loginService.login(form.value).subscribe({
			next: (res:any) => {
				if(res.success){
					localStorage.setItem('token', res.data);
					this.router.navigate(["admin"]);
				}
			},
			error: (err:any) => {
				this.message = err.error.message;
			}
		})
	}
}
