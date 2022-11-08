import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrlShortenerHistoryComponent } from './url-shortener-history.component';

describe('UrlShortenerHistoryComponent', () => {
  let component: UrlShortenerHistoryComponent;
  let fixture: ComponentFixture<UrlShortenerHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrlShortenerHistoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UrlShortenerHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
