import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {

  baseUrl = environment.apiRul;
  validationErrors: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get500Error() {
    this.http.get(`${this.baseUrl}buggy/servererror`).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

  get404Error() {
    this.http.get(`${this.baseUrl}buggy/notfound`).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }
  get400Error() {
    this.http.get(`${this.baseUrl}buggy/badrequest`).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }
  get422Error() {
    this.http.get(`${this.baseUrl}buggy/unprocessable/forty`).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
      this.validationErrors = error.errors;
    })
  }

}
