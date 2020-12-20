import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowNalogComponent } from './show-nalog.component';

describe('ShowNalogComponent', () => {
  let component: ShowNalogComponent;
  let fixture: ComponentFixture<ShowNalogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowNalogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowNalogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
