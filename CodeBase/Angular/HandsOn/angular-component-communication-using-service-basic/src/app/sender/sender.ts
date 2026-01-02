import { Component } from '@angular/core';
import { DataSharingService } from '../services/data-sharing';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router'; 

@Component({
  standalone: true,
  selector: 'app-sender',
  template: `
    <input #msg />
    <button (click)="send(msg.value)">Send</button>
  `
})
export class Sender {

  constructor(private dataService: DataSharingService, private router: Router) { }

  send(value: string) {
    this.dataService.message = value;
    this.router.navigate(['/receiver']);

  }
}

