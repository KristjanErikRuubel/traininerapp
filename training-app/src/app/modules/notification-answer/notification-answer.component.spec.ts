import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationAnswerComponent } from './notification-answer.component';

describe('NotificationAnswerComponent', () => {
  let component: NotificationAnswerComponent;
  let fixture: ComponentFixture<NotificationAnswerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotificationAnswerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotificationAnswerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
