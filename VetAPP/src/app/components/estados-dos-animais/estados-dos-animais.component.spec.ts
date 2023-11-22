import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstadosDosAnimaisComponent } from './estados-dos-animais.component';

describe('EstadosDosAnimaisComponent', () => {
  let component: EstadosDosAnimaisComponent;
  let fixture: ComponentFixture<EstadosDosAnimaisComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EstadosDosAnimaisComponent]
    });
    fixture = TestBed.createComponent(EstadosDosAnimaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
