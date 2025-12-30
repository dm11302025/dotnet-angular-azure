import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Parent } from "./parent/parent";
import { Parent1 } from "./parent-1/parent-1";
import { Student } from './student';
import { StudentDetail } from './student-detail/student-detail';
import { StudentList } from './student-list/student-list';
@Component({
  selector: 'app-root',
  imports: [Parent, Parent1, StudentDetail, StudentList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  
  selectedStudent?: Student;

  onStudentSelected(student: Student) {
    this.selectedStudent = student;
  }
}
