import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataSharingService {

  private messageSource = new BehaviorSubject<string>('Initial Message');

  message$ = this.messageSource.asObservable();

  updateMessage(newMessage: string): void {
    this.messageSource.next(newMessage);
  }
}
