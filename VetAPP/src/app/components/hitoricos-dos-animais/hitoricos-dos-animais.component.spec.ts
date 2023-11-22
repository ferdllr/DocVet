import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HitoricosDosAnimaisComponent } from './hitoricos-dos-animais.component';

describe('HitoricosDosAnimaisComponent', () => {
  let component: HitoricosDosAnimaisComponent;
  let fixture: ComponentFixture<HitoricosDosAnimaisComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HitoricosDosAnimaisComponent]
    });
    fixture = TestBed.createComponent(HitoricosDosAnimaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
