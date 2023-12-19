import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditArticlePageComponent } from './edit-article-page.component';

describe('EditArticlePageComponent', () => {
  let component: EditArticlePageComponent;
  let fixture: ComponentFixture<EditArticlePageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditArticlePageComponent]
    });
    fixture = TestBed.createComponent(EditArticlePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
