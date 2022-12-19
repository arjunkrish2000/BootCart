import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-product-master-registration',
  templateUrl: './product-master-registration.component.html',
  styleUrls: ['./product-master-registration.component.css']
})
export class ProductMasterRegistrationComponent {
  constructor(private registerService:AuthService, private router:Router) { }

  handleRegister(form:any){
    console.log(form.value);
    this.registerService.register(form.value).subscribe({
        next:(responce)=>{
          console.log(responce);
        }
    })
  }
}
