import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageTrainingplacesComponent } from './manage-trainingplaces.component';

describe('ManageTrainingplacesComponent', () => {
  let component: ManageTrainingplacesComponent;
  let fixture: ComponentFixture<ManageTrainingplacesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageTrainingplacesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageTrainingplacesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
