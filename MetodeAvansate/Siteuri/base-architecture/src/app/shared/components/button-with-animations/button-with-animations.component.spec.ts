import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonWithAnimationsComponent } from './button-with-animations.component';

describe('ButtonWithAnimationsComponent', () => {
  let component: ButtonWithAnimationsComponent;
  let fixture: ComponentFixture<ButtonWithAnimationsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ButtonWithAnimationsComponent]
    });
    fixture = TestBed.createComponent(ButtonWithAnimationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
