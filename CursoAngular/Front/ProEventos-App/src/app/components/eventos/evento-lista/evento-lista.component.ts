import { Component, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventoService } from 'src/app/services/evento.service';
import { Evento } from 'src/app/models/Evento';
import { Router } from '@angular/router';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent {
  modalRef?:BsModalRef;


  constructor(
    private eventoService : EventoService,
    private modalService: BsModalService,
    private toastr : ToastrService,
    private spinner: NgxSpinnerService,
    private router : Router
    ) { }

  public ngOnInit(): void {
      this.spinner.show();
      this.getEventos();

  }
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


  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Eventos', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>):void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success("O Evento foi deletado com Sucesso!","Deletado!");
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheEvento(id:number):void{
    this.router.navigate([`/eventos/detalhe/${id}`]);
  }
}
