import { TestBed } from '@angular/core/testing';

import { HistoricosDosAnimaisService } from './historicos-dos-animais.service';

describe('HistoricosDosAnimaisService', () => {
  let service: HistoricosDosAnimaisService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HistoricosDosAnimaisService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
