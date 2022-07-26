/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InscritosListComponent } from './inscritos-list.component';

describe('InscritosListComponent', () => {
  let component: InscritosListComponent;
  let fixture: ComponentFixture<InscritosListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InscritosListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InscritosListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
