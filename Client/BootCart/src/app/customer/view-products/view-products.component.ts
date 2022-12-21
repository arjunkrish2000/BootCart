import { Component } from '@angular/core';
import { response } from 'express';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent {
  products:any
	constructor(private customerService:CustomerService) { }

	ngOnInit() {
    this.customerService.ViewProducts()
      .subscribe(response => {
        this.products = response;
        console.log(response);
      });
}
}
