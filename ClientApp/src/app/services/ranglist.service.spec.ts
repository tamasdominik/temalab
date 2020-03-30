import { TestBed } from '@angular/core/testing';

import { RanglistService } from './ranglist.service';

describe('RanglistService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RanglistService = TestBed.get(RanglistService);
    expect(service).toBeTruthy();
  });
});
