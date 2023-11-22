import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlimentacoesComponent } from './alimentacoes.component';

describe('AlimentacoesComponent', () => {
  let component: AlimentacoesComponent;
  let fixture: ComponentFixture<AlimentacoesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlimentacoesComponent]
    });
    fixture = TestBed.createComponent(AlimentacoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
