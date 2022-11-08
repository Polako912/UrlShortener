import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { UrlShortenerFacade } from 'src/app/url-shortener.facade';

@Component({
  selector: 'app-url-shortener-home',
  templateUrl: './url-shortener-home.component.html',
  styleUrls: ['./url-shortener-home.component.scss']
})
export class UrlShortenerHomeComponent implements OnInit {

  urlFormControl = new FormControl('', [Validators.required]);

  matcher = new MyErrorStateMatcher();

  constructor(private facade: UrlShortenerFacade) { }

  shortUrl: string;
  error: string;

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.urlFormControl.valid) {
      this.facade.createUrl(this.urlFormControl.value).subscribe(data => {
        this.shortUrl = data
      },
      err => {
        this.error = err.error
      });
    } else {
      console.error("Form is invalid!");
    }
  }
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
