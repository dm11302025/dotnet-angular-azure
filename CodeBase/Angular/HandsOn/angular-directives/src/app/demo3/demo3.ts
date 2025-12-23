import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-demo3',
  imports: [CommonModule, FormsModule],
  templateUrl: './demo3.html',
  styleUrl: './demo3.css'
})
export class Demo3 {
  roles: string[] = ['editor', 'admin', 'viewer']
  userRole = 'unknown';

}
