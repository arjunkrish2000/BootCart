import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StaticDetails } from '../helpers/staticDetails';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http:HttpClient) { }

  ViewProducts(){
    return this.http.get(`${StaticDetails.API_URL}/customer/viewproducts`);
  }
  ViewOrderHistory(){
    return this.http.get(`${StaticDetails.API_URL}/customer/orderhistory`)
  }
  ViewUserProfile(){
    return this.http.get(`${StaticDetails.API_URL}/customer/updateprofile`)
  }
  ViewCart(){
    return this.http.get(`${StaticDetails.API_URL}/customer/viewcart`)
  }
  AddToCart(productId:any){
    return this.http.post(`${StaticDetails.API_URL}/customer/addtocart`,productId)
  }
}
