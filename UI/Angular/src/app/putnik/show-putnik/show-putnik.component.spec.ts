import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPutnikComponent } from './show-putnik.component';

describe('ShowPutnikComponent', () => {
  let component: ShowPutnikComponent;
  let fixture: ComponentFixture<ShowPutnikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPutnikComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowPutnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
