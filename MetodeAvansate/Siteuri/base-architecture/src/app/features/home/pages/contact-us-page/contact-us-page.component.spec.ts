import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactUsPageComponent } from './contact-us-page.component';

describe('ContactUsPageComponent', () => {
  let component: ContactUsPageComponent;
  let fixture: ComponentFixture<ContactUsPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContactUsPageComponent]
    });
    fixture = TestBed.createComponent(ContactUsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
