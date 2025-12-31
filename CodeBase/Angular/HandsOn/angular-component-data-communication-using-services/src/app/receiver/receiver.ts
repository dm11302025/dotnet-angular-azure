import { Component, OnInit } from '@angular/core';
import { DataSharingService } from '../services/data-sharing';

@Component({
  selector: 'app-receiver',
  template: `
    <h3>Receiver Component</h3>
    <p>Received Message: {{ message }}</p>
  `
})
export class ReceiverComponent implements OnInit {

  message!: string;

  constructor(private dataService: DataSharingService) {}

  ngOnInit(): void {
    this.dataService.message$.subscribe(value => {
      this.message = value;
    });
  }
}
