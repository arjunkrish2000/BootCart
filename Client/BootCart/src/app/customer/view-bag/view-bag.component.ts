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
  pid:any
  constructor(private route:ActivatedRoute,private customerService:CustomerService,private router:Router){}
  
  ngOnInit(){
    this.productId = Number(this.route.snapshot.paramMap.get('id'));
    console.log(this.productId);
    this.pid = parseInt(this.productId);
    
    this.customerService.AddToCart(this.pid).subscribe({
      next:(responce)=>{
        console.log(responce);
        this.router.navigate(['view-bag'])
      }
  })

    this.customerService.ViewCart()
      .subscribe(response => {
        this.cart = response;
        console.log(response);
        this.router.navigate(['view-bag'])
      });
  }
  
}
