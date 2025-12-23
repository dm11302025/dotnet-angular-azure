import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-project',
  imports: [CommonModule, FormsModule],
  templateUrl: './project.html',
  styleUrl: './project.css'
})
export class Project {
  userRole = 'admin';

  tasks = [
    { title: "Prepare project report", priority: "High", done: false },
    { title: "Team meeting", priority: "Medium", done: true },
    { title: "Code review", priority: "Low", done: false },
    { title: "Update documentation", priority: "Medium", done: true }
  ];

  newTask = { title: '', priority: '', done: false };
  editTask = { title: '', priority: '', done: false };
  editIndex: number | null = null;

  deleteIndex: number | null = null;

  toggleTaskStatus(task: any) {
    task.done = !task.done;
  }

  addTask() {
    if (this.newTask.title && this.newTask.priority) {
      this.tasks.push({ ...this.newTask, done: false });
      this.newTask = { title: '', priority: '', done: false };
    }
  }

  openEditTask(task: any, index: number) {
    this.editTask = { ...task };
    this.editIndex = index;
  }

  updateTask() {
    if (this.editIndex !== null) {
      this.tasks[this.editIndex] = { ...this.editTask };
      this.editTask = { title: '', priority: '', done: false };
      this.editIndex = null;
    }
  }

  confirmDeleteTask(index: number) {
    this.deleteIndex = index;
  }

  deleteTask() {
    if (this.deleteIndex !== null) {
      this.tasks.splice(this.deleteIndex, 1);
      this.deleteIndex = null;
    }
  }
}
