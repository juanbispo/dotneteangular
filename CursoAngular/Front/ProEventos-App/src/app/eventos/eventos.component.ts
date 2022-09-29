import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  constructor( private http : HttpClient) { }

  public eventos : any = [];
  public eventosFiltrados : any = [];

  isCollapsed = true;

  private _filtroLista:string = '';

  public get filtroLista():string{
    return this._filtroLista;
  }

  public set filtroLista(value:string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarLista(this.filtroLista) : this.eventos;
  }

  filtrarLista(filtrarPor : string) : any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
                      || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }


  ngOnInit(): void {
      this.getEventos();
  }

  public getEventos():void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response,
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );
  }

}
