import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTrainingplaceComponent } from './edit-trainingplace.component';

describe('EditTrainingplaceComponent', () => {
  let component: EditTrainingplaceComponent;
  let fixture: ComponentFixture<EditTrainingplaceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditTrainingplaceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditTrainingplaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
