/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LiveService } from './Live.service';

describe('Service: Live', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LiveService]
    });
  });

  it('should ...', inject([LiveService], (service: LiveService) => {
    expect(service).toBeTruthy();
  }));
});
