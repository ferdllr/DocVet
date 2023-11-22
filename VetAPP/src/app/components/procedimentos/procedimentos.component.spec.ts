import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcedimentosComponent } from './procedimentos.component';

describe('ProcedimentosComponent', () => {
  let component: ProcedimentosComponent;
  let fixture: ComponentFixture<ProcedimentosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProcedimentosComponent]
    });
    fixture = TestBed.createComponent(ProcedimentosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
