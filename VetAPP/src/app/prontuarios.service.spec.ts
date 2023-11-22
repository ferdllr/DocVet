import { TestBed } from '@angular/core/testing';

import { ProntuariosService } from './prontuarios.service';

describe('ProntuariosService', () => {
  let service: ProntuariosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProntuariosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
