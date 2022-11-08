import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, of } from "rxjs";
import { environment } from "src/environments/environment";
import { ShortenedUrl } from "./models/shortened-url";

@Injectable({
    providedIn: 'root'
  })
export class UrlShortenerService {

    constructor(public http: HttpClient) {}

    headers = new HttpHeaders({
        Accept: 'application/json',
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept',
        'Access-Control-Allow-Methods': 'GET,PUT,OPTIONS'
      });
    
      httpOptions = {
        headers: this.headers
      };

    apiUrl = environment.apiUrl;

    getHistory(): Observable<ShortenedUrl[]> {
        return this.http.get<ShortenedUrl[]>(this.apiUrl + `/all`, {
            headers: this.headers
        })
        .pipe(
            catchError(this.handleError<ShortenedUrl[]>('getHistory', []))
        );
    }

    createShortUrl(sourceUrl: string | null): Observable<string> {
      return this.http.post<string>(this.apiUrl + `/short-url?sourceUrl=` + sourceUrl, {
        headers: this.headers
      }, { responseType: 'text' as 'json'});
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
          console.error(error); 
          return of(result as T);
        };
    }
}