/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InstrutoresService } from './instrutores.service';

describe('Service: Instrutores', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InstrutoresService]
    });
  });

  it('should ...', inject([InstrutoresService], (service: InstrutoresService) => {
    expect(service).toBeTruthy();
  }));
});
