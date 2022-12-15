import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  authService: any;
  constructor(private registerService:AuthService, private router:Router) { }

  handleRegister(form:any){
    console.log(form.value);
    this.authService.register(form.value).subscribe({
        next:(responce:any)=>{
          console.log(responce);
        }
    })
  }
}
