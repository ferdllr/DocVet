import { TestBed } from '@angular/core/testing';

import { VacinasService } from './vacinas.service';

describe('VacinasService', () => {
  let service: VacinasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VacinasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
