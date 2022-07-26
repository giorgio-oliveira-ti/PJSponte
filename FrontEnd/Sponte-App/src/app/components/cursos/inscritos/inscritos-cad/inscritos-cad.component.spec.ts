/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InscritosCadComponent } from './inscritos-cad.component';

describe('InscritosCadComponent', () => {
  let component: InscritosCadComponent;
  let fixture: ComponentFixture<InscritosCadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InscritosCadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InscritosCadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
