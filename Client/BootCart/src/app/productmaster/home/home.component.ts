import { Component } from '@angular/core';
import { ViewProductsComponent } from 'src/app/admin/view-products/view-products.component';
import { ProductMasterService } from '../product-master.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  products:any
  constructor(private pmService:ProductMasterService,){}

  ngOnInit() {
    this.pmService.ViewStock()
      .subscribe(response => {
        this.products = response;
        console.log(response);
      });
}

}
