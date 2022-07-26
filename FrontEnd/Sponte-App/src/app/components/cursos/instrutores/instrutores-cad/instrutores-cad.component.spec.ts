/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InstrutoresCadComponent } from './instrutores-cad.component';

describe('InstrutoresCadComponent', () => {
  let component: InstrutoresCadComponent;
  let fixture: ComponentFixture<InstrutoresCadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstrutoresCadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstrutoresCadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
