import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPutnikComponent } from './add-edit-putnik.component';

describe('AddEditPutnikComponent', () => {
  let component: AddEditPutnikComponent;
  let fixture: ComponentFixture<AddEditPutnikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPutnikComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPutnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
