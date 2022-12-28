import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  constructor(private eventoService : EventoService) { }

  public eventos : Evento[] = [];
  public eventosFiltrados : Evento[] = [];

  isCollapsed = true;

  private filtroListado:string = '';

  public get filtroLista():string{
    return this.filtroListado;
  }

  public set filtroLista(value:string){
    this.filtroListado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarLista(this.filtroLista) : this.eventos;
  }

  public filtrarLista(filtrarPor : string) : Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
                      || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  public ngOnInit(): void {
      this.getEventos();
  }

  public getEventos():void{
    this.eventoService.getEventos().subscribe(
      (eventosResponse : Evento[]) => {
        this.eventos = eventosResponse,
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }

}
