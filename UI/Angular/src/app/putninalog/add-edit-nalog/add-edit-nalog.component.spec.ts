import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditNalogComponent } from './add-edit-nalog.component';

describe('AddEditNalogComponent', () => {
  let component: AddEditNalogComponent;
  let fixture: ComponentFixture<AddEditNalogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditNalogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditNalogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  
});
