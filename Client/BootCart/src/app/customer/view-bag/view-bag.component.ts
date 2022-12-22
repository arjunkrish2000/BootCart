import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-view-bag',
  templateUrl: './view-bag.component.html',
  styleUrls: ['./view-bag.component.css']
})
export class ViewBagComponent {
  productId:any
  cart:any
  constructor(private route:ActivatedRoute,private customerService:CustomerService,private router:Router){}
  ngOnInit(){
    const productId = Number(this.route.snapshot.paramMap.get('id'));
    console.log(productId);

    this.customerService.AddToCart(productId).subscribe({
      next:(responce)=>{
        console.log(responce);
      }
  })

    this.customerService.ViewCart()
      .subscribe(response => {
        this.cart = response;
        console.log(response);
      });
  }
  
}
