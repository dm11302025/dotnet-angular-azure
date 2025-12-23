import { Component } from '@angular/core';
import { RouterModule, RouterOutlet, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  imports: [RouterOutlet, RouterModule],
  templateUrl: './admin-dashboard.html',
  styleUrl: './admin-dashboard.css'
})
export class AdminDashboard {
  username: string = '';
  constructor(private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.username = params['uname'];
      console.log(params['uname']);
    });
  }
}
