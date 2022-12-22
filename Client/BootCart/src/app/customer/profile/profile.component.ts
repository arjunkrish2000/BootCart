import { Component } from '@angular/core';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  users:any
	constructor(private customerService:CustomerService) { }

	ngOnInit() {
    this.customerService.ViewUserProfile()
      .subscribe(response => {
        this.users = response;
        console.log(response);
      });
}
}
