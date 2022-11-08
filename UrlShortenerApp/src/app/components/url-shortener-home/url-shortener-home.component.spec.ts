import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrlShortenerHomeComponent } from './url-shortener-home.component';

describe('UrlShortenerHomeComponent', () => {
  let component: UrlShortenerHomeComponent;
  let fixture: ComponentFixture<UrlShortenerHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrlShortenerHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UrlShortenerHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
