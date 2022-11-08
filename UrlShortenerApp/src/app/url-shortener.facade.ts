import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ShortenedUrl } from "./models/shortened-url";
import { UrlShortenerService } from "./url-shortener.service";

@Injectable({
    providedIn: 'root'
  })
export class UrlShortenerFacade {
    constructor(private service: UrlShortenerService) {

    }

    loadUrlHistory(): Observable<ShortenedUrl[]> {
        return this.service.getHistory();
    }

    createUrl(sourceUrl: string | null): Observable<string> {
        return this.service.createShortUrl(sourceUrl);
    }
}