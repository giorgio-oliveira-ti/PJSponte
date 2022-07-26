/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InscritosService } from './Inscritos.service';

describe('Service: Inscritos', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InscritosService]
    });
  });

  it('should ...', inject([InscritosService], (service: InscritosService) => {
    expect(service).toBeTruthy();
  }));
});
