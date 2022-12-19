import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import jwt_decode from "jwt-decode";
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
	message: string = '';
	constructor(private loginService:AuthService, private router:Router,private cookieService: CookieService) { }

	checkLogin(form: NgForm){
		this.loginService.login(form.value).subscribe({
			next: (res:any) => {
				if(res.success){
					localStorage.setItem('token', res.data);
					var decodedToken:any = jwt_decode(res.data);
					console.log(decodedToken);
					console.log(decodedToken.Role);
					this.cookieService.set('Email', decodedToken.Email);
					console.log(this.cookieService.get('Email'));
					switch(decodedToken.Role){
						case "Admin":
							this.router.navigate(["/admin"]);
							break;
						case "Customer":
							this.router.navigate(["/customer"]);
							break;
						case "ProductMaster":
							this.router.navigate(["/productmaster"])
					}
				}
			},
			error: (err:any) => {
				this.message = err.error.message;
			}
		});
	}
}
