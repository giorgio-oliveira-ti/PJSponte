/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InscritosComponent } from './inscritos.component';

describe('InscritosComponent', () => {
  let component: InscritosComponent;
  let fixture: ComponentFixture<InscritosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InscritosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InscritosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
