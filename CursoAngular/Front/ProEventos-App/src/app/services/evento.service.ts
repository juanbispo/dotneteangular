import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

constructor( private http : HttpClient) { }

  baseUrl = 'https://localhost:5001/api/eventos';


  getEventos() : Observable<Evento[]>{
    return this.http.get<Evento[]>(this.baseUrl);
  }

  getEventosByTema(tema:string) : Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseUrl}/tema/${tema}`);
  }

  getEventoById(id : number) : Observable<Evento>{
    return this.http.get<Evento>(`${this.baseUrl}/${id}`);
  }
}
