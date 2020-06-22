import { TestBed } from '@angular/core/testing';

import { TrainingPlaceService } from './training-place.service';

describe('TrainingPlaceService', () => {
  let service: TrainingPlaceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrainingPlaceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
