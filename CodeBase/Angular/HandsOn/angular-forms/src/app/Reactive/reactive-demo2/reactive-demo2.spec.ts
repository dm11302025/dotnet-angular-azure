import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReactiveDemo2 } from './reactive-demo2';

describe('ReactiveDemo2', () => {
  let component: ReactiveDemo2;
  let fixture: ComponentFixture<ReactiveDemo2>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveDemo2]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReactiveDemo2);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
