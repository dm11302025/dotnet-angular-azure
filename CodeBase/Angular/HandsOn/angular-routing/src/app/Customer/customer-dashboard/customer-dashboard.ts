import { Component } from '@angular/core';
import { RouterLink, RouterModule, RouterOutlet, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer-dashboard',
  imports: [RouterOutlet, RouterModule],
  templateUrl: './customer-dashboard.html',
  styleUrl: './customer-dashboard.css'
})
export class CustomerDashboard {
  username: string = '';
  constructor(private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.username = params['uname'];
      console.log(params['uname']);
    });
  }
}
