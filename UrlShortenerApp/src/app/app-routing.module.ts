import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UrlShortenerHistoryComponent } from './components/url-shortener-history/url-shortener-history.component';
import { UrlShortenerHomeComponent } from './components/url-shortener-home/url-shortener-home.component';

const routes: Routes = [
  { path: '', component: UrlShortenerHomeComponent },
  { path: 'history', component: UrlShortenerHistoryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
