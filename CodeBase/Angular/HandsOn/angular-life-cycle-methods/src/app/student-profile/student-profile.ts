import {
  Component,
  Input,
  OnInit,
  OnChanges,
  SimpleChanges,
  AfterViewInit,
  OnDestroy,
  ViewChild,
  ElementRef
} from '@angular/core';

@Component({
  selector: 'app-student-profile',
  standalone: true,
  templateUrl: './student-profile.html'
})
export class StudentProfileComponent
  implements OnInit, OnChanges, AfterViewInit, OnDestroy {

  @Input() studentName!: string;

  //@ViewChild('title') title!: ElementRef;

  constructor() {
    console.log('Constructor: Component created');
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log('ngOnChanges:', changes);
  }

  ngOnInit(): void {
    console.log('ngOnInit: Initialization logic');
    // API calls, default values, subscriptions
  }

  ngAfterViewInit(): void {
    console.log('ngAfterViewInit: View initialized');
    //this.title.nativeElement.style.color = 'blue';
  }

  ngOnDestroy(): void {
    console.log('ngOnDestroy: Cleanup');
    // unsubscribe, clear timers
  }
}
