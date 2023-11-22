import { TestBed } from '@angular/core/testing';

import { EstadosDosAnimaisService } from './estados-dos-animais.service';

describe('EstadosDosAnimaisService', () => {
  let service: EstadosDosAnimaisService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EstadosDosAnimaisService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
