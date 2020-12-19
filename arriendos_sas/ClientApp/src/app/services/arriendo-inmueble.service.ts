import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ArriendoInmueble } from '../arriendo/models/arriendo-inmueble';

@Injectable({
  providedIn: 'root'
})
export class ArriendoInmuebleService {

  baseUrl: string;
  apiUrl = 'api/arriendoinmueble/';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL')baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  get(): Observable<ArriendoInmueble[]>{
    return this.http.get<ArriendoInmueble[]>(this.baseUrl + this.apiUrl);
  }

  post(arriendoInmueble: ArriendoInmueble): Observable<ArriendoInmueble>{
    return this.http.post<ArriendoInmueble>(this.baseUrl + this.apiUrl, arriendoInmueble);
  }
}
