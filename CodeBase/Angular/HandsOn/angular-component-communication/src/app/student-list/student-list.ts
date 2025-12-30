import { Component, EventEmitter, Output } from '@angular/core';
import { Student } from '../student';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student-list',
  imports: [CommonModule],
  templateUrl: './student-list.html',
  styleUrl: './student-list.css'
})
export class StudentList {
  @Output() studentSelected = new EventEmitter<Student>();
  students: Student[] = [
    { id: 1, name: 'Rahul', age: 15, grade: 'A' },
    { id: 2, name: 'Anita', age: 14, grade: 'B' },
    { id: 3, name: 'Vikram', age: 16, grade: 'A+' }
  ];
  onSelect(student: Student) {
    this.studentSelected.emit(student);  // emit selected student
  }
}
