import { Component, Input } from '@angular/core';
import { Student } from '../student';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student-detail',
  imports: [CommonModule],
  templateUrl: './student-detail.html',
  styleUrl: './student-detail.css'
})
export class StudentDetail {
  @Input() student?: Student; // receive data
}
