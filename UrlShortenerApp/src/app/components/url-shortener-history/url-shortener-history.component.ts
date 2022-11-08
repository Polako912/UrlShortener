import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { ShortenedUrl } from 'src/app/models/shortened-url';
import { UrlShortenerFacade } from 'src/app/url-shortener.facade';

@Component({
  selector: 'app-url-shortener-history',
  templateUrl: './url-shortener-history.component.html',
  styleUrls: ['./url-shortener-history.component.scss']
})
export class UrlShortenerHistoryComponent implements OnInit {
  constructor(private facade: UrlShortenerFacade) { }

  results$: Observable<ShortenedUrl[]> = new Observable;

  displayedColumns: string[] = ['order', 'sourceUrl', 'shortUrl'];

  ngOnInit(): void {
    this.results$ = this.facade.loadUrlHistory();
  }
}
