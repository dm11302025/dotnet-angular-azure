import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateDemo2 } from './template-demo2';

describe('TemplateDemo2', () => {
  let component: TemplateDemo2;
  let fixture: ComponentFixture<TemplateDemo2>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TemplateDemo2]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemplateDemo2);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
