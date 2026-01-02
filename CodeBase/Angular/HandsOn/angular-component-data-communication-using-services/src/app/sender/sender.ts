import { Component } from '@angular/core';
import { DataSharingService } from '../services/data-sharing';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sender',
  imports: [FormsModule],
  template: `
    <h3>Sender Component</h3>
    <input type="text" [(ngModel)]="message" />
    <button (click)="send()">Send</button>
  `
})
export class Sender {

  constructor(private dataService: DataSharingService, private router: Router) { }
  //nullable message property
  message!: string;
  send(): void {
    console.log('Sending message:', this.message);
    // Update the message in the service
    this.dataService.updateMessage(this.message);
    this.router.navigate(['/receiver']);
  }
}
