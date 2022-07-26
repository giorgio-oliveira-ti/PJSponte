import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Inscrito } from '@app/models/inscrito';
import { InscritosService } from '@app/services/Inscritos.service';
import { NgxSpinnerService } from 'ngx-bootstrap-spinner';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-inscritos-list',
  templateUrl: './inscritos-list.component.html',
  styleUrls: ['./inscritos-list.component.css']
})
export class InscritosListComponent implements OnInit {

  modalRef?: BsModalRef;
  toastr: any;

  public Inscritos: any = [];
  public InscritosListados: any = [];
  public InscritoId = 0;
  private  _BuscarList: string = '';



 ////Formatação do campo Datepicker /////
public get bsconfigDatepicker(): any{
  return {
    isAnimated:true,
    adaptivePosition:true,
    ShowWeekNumbers: false,
    containerClass: 'theme-dark-blue',
    //dateInputFormat: 'DD/MM/YYYY hh:mm',
}
}

  constructor(
    private modalService: BsModalService,
    private toastrService: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router,
    private inscritosService :InscritosService,

  ) { }

  ngOnInit():void {
    this.spinner.show();
    this.getInscritos();
  }
  public get BuscarList(): string {
    return this._BuscarList;
  }
  public set BuscarList(value: string ){
    this._BuscarList = value;
   this.InscritosListados = this.BuscarList ?  this.buscarListaInscritos(this.BuscarList) : this.Inscritos  ;
  }

  public buscarListaInscritos(buscarTabelaPor: string): any {
    buscarTabelaPor = buscarTabelaPor.toLocaleLowerCase();
    return this.InscritosListados.filter(
      (Inscrito: { nome: string; dataNascimento: string; email: string;
      }) => Inscrito.nome.toLocaleLowerCase().indexOf(buscarTabelaPor) !== -1 ||
      Inscrito.dataNascimento.toLocaleLowerCase().indexOf(buscarTabelaPor) !== -1 ||
      Inscrito.email.toLocaleLowerCase().indexOf(buscarTabelaPor) !== -1


     )
  }

  public getInscritos(): void {

    this.inscritosService.getInscrito().subscribe({
     next:(_Inscritos: Inscrito[]): void =>{
       this.Inscritos = _Inscritos;
       this.InscritosListados = this.Inscritos;
     },
     error:(error: any) => {
       this.toastrService.error('Erro ao localizar o Inscritos', 'Error!');
     },
    }).add(()=>this.spinner.hide())
 }

 openModal(event: any, template: TemplateRef<any>, InscritoId: number): void {
  event.stopPropagation();
  this.InscritoId = InscritoId;
  this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
}

confirm(): void {
  this.modalRef?.hide();
  this.spinner.show();
  this.inscritosService.deleteInscrito(this.InscritoId).subscribe({
    next: (result: string)=>{
        this.toastrService.success('Inscritos Excluido.', 'sucesso!');
        this.getInscritos();
    },
    error:(error: any)=>{
      this.toastrService.error(`Erro ao excluir o Inscritos. ${this.InscritoId}`, 'Erro!');
    },
  }).add(()=> this.spinner.hide());
}

public decline(): void {
  this.modalRef?.hide();
}

cadEnvio(id: number): void{
  this.router.navigate([`/Inscritos/cad/${id}`])
}
}
