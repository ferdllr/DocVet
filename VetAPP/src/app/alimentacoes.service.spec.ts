import { TestBed } from '@angular/core/testing';

import { AlimentacoesService } from './alimentacoes.service';

describe('AlimentacoesService', () => {
  let service: AlimentacoesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AlimentacoesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
