import { TestBed } from '@angular/core/testing';

import { ExamesService } from './exames.service';

describe('ExamesService', () => {
  let service: ExamesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
