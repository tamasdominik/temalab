import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewWorkoutComponent } from './add-new-workout.component';

describe('AddNewWorkoutComponent', () => {
  let component: AddNewWorkoutComponent;
  let fixture: ComponentFixture<AddNewWorkoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddNewWorkoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNewWorkoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
