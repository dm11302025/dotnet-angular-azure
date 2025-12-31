import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReactiveDemo1 } from './reactive-demo1';

describe('ReactiveDemo1', () => {
  let component: ReactiveDemo1;
  let fixture: ComponentFixture<ReactiveDemo1>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveDemo1]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReactiveDemo1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
