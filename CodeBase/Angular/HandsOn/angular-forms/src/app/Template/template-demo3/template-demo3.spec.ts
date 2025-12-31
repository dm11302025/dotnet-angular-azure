import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateDemo3 } from './template-demo3';

describe('TemplateDemo3', () => {
  let component: TemplateDemo3;
  let fixture: ComponentFixture<TemplateDemo3>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TemplateDemo3]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemplateDemo3);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
