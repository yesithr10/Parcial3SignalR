import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Inmueble } from '../arriendo/models/inmueble';

@Injectable({
  providedIn: 'root'
})
export class InmuebleService {

  baseUrl: string;
  apiUrl = 'api/inmueble/';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL')baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  get(): Observable<Inmueble[]>{
    return this.http.get<Inmueble[]>(this.baseUrl + this.apiUrl);
  }

  post(inmueble: Inmueble): Observable<Inmueble>{
    return this.http.post<Inmueble>(this.baseUrl + this.apiUrl, inmueble);
  }
}
