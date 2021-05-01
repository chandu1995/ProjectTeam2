import { TestBed } from '@angular/core/testing';

import { PmsService } from './pms.service';

describe('PmsService', () => {
  let service: PmsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PmsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
