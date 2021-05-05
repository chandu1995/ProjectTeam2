import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrackByOrderDetailsComponent } from './track-by-order-details.component';

describe('TrackByOrderDetailsComponent', () => {
  let component: TrackByOrderDetailsComponent;
  let fixture: ComponentFixture<TrackByOrderDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrackByOrderDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TrackByOrderDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
