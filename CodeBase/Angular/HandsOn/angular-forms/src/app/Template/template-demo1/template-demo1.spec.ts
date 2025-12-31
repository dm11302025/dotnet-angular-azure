import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateDemo1 } from './template-demo1';

describe('TemplateDemo1', () => {
  let component: TemplateDemo1;
  let fixture: ComponentFixture<TemplateDemo1>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TemplateDemo1]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemplateDemo1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
