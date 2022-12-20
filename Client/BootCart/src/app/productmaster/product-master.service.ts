import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StaticDetails } from '../helpers/staticDetails';

@Injectable({
  providedIn: 'root'
})
export class ProductMasterService {

  constructor(private http: HttpClient) { }

  ViewStock(){
    return this.http.get(`${StaticDetails.API_URL}/productmaster/viewstock`)
  }
  AddProduct(data: any){
    return this.http.post(`${StaticDetails.API_URL}/productmaster/addproduct`, data);
  }
  AddSpecification(data:any){
    return this.http.post(`${StaticDetails.API_URL}/productmaster/addproductspecification`, data);
  }
}
