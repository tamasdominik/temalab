import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RanglistComponent } from './ranglist.component';

describe('RanglistComponent', () => {
  let component: RanglistComponent;
  let fixture: ComponentFixture<RanglistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RanglistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RanglistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
