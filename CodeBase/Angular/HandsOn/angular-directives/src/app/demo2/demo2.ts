import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-demo2',
  imports: [CommonModule],
  templateUrl: './demo2.html',
  styleUrl: './demo2.css'
})
export class Demo2 {
  isLoggedIn = true;
  username = "San";
  logOut(): void {
    this.isLoggedIn = false;
  }
  logIn(): void {
    this.isLoggedIn = true;
  }
}
