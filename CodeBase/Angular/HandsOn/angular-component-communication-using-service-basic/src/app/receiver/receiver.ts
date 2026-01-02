import { Component, OnInit } from '@angular/core';
import { DataSharingService } from '../services/data-sharing';

@Component({
  standalone: true,
  selector: 'app-receiver',
  template: `
    <p>Message: {{ message }}</p>
  `
})
export class Receiver implements OnInit {

  message = '';

  constructor(private dataService: DataSharingService) { }

  ngOnInit() {
    this.message = this.dataService.message;
  }
}

