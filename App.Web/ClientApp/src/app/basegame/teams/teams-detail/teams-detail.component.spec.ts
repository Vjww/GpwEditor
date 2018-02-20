import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamsDetailComponent } from './teams-detail.component';

describe('TeamsDetailComponent', () => {
  let component: TeamsDetailComponent;
  let fixture: ComponentFixture<TeamsDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeamsDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
