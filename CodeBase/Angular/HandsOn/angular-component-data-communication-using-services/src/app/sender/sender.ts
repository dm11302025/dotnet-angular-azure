import { Component } from '@angular/core';
import { DataSharingService } from '../services/data-sharing';

@Component({
  selector: 'app-sender',
  template: `
    <h3>Sender Component</h3>
    <input type="text" #msg />
    <button (click)="send(msg.value)">Send</button>
  `
})
export class Sender {

  constructor(private dataService: DataSharingService) {}

  send(value: string): void {
    this.dataService.updateMessage(value);
  }
}
