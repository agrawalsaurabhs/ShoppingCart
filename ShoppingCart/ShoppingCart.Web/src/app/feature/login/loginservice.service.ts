import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class LoginserviceService {

  constructor(private http: HttpClient) { }

  getFoods() {
    return this.http.get('/api/food');
  }

}
