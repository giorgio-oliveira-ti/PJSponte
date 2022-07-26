/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InstrutoresComponent } from './instrutores.component';

describe('InstrutoresComponent', () => {
  let component: InstrutoresComponent;
  let fixture: ComponentFixture<InstrutoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstrutoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstrutoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
