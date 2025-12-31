import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReactiveDemo3 } from './reactive-demo3';

describe('ReactiveDemo3', () => {
  let component: ReactiveDemo3;
  let fixture: ComponentFixture<ReactiveDemo3>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveDemo3]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReactiveDemo3);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
