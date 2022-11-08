import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { UrlShortenerHomeComponent } from './components/url-shortener-home/url-shortener-home.component';
import { UrlShortenerHistoryComponent } from './components/url-shortener-history/url-shortener-history.component';
import { UrlShortenerFacade } from './url-shortener.facade';
import { UrlShortenerService } from './url-shortener.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    UrlShortenerHomeComponent,
    UrlShortenerHistoryComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MaterialModule,
    FlexLayoutModule,
    HttpClientModule
  ],
  providers: [
    UrlShortenerFacade,
    UrlShortenerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
