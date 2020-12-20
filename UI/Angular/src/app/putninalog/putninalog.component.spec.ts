import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PutninalogComponent } from './putninalog.component';

describe('PutninalogComponent', () => {
  let component: PutninalogComponent;
  let fixture: ComponentFixture<PutninalogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PutninalogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PutninalogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
