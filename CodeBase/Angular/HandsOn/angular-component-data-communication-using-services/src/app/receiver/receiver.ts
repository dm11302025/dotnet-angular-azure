import { Component, OnInit } from '@angular/core';
import { DataSharingService } from '../services/data-sharing';

@Component({
  selector: 'app-receiver',
  template: `
    <h3>Receiver Component</h3>
    <p>Received Message: {{ message }}</p>
  `
})
export class Receiver implements OnInit {

  message!: string;

  constructor(private dataService: DataSharingService) { }

  ngOnInit(): void {
    // Subscribe to the message observable to get updates
    this.dataService.message$.subscribe(value => {
      console.log('Received message:', value);
      this.message = value;
      console.log('Updated local message property:', this.message);
    });
  }
}
