
import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Instrutor } from '@app/models/instrutor';
import { NgxSpinnerService } from 'ngx-bootstrap-spinner';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { InstrutoresService } from './../../../../services/instrutores.service';

@Component({
  selector: 'app-instrutores-list',
  templateUrl: './instrutores-list.component.html',
  styleUrls: ['./instrutores-list.component.css']
})
export class InstrutoresListComponent implements OnInit {

  modalRef?: BsModalRef;
  toastr: any;

  public Instrutores: any = [];
  public InstrutoresListados: any = [];
  public InstrutorId = 0;
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
    private instrutoreesService : InstrutoresService
    ) { }

  ngOnInit():void {
    this.spinner.show();
    this.getInstrutores();
  }

  public get BuscarList(): string {
    return this._BuscarList;
  }

  public set BuscarList(value: string ){
    this._BuscarList = value;
   this.InstrutoresListados = this.BuscarList ?  this.buscarListaInstrutores(this.BuscarList) : this.Instrutores  ;
  }

  public buscarListaInstrutores(buscarTabelaPor: string): any {
    buscarTabelaPor = buscarTabelaPor.toLocaleLowerCase();
    return this.InstrutoresListados.filter(
      (Instrutores: { nome: string; dataNascimento: string; email: string; andInstagram: string;
      }) => Instrutores.nome.toLocaleLowerCase().indexOf(buscarTabelaPor) !== -1 ||
      Instrutores.dataNascimento.toLocaleLowerCase().indexOf(buscarTabelaPor) !== -1 ||
      Instrutores.email.toLocaleLowerCase().indexOf(buscarTabelaPor) !== -1 ||
      Instrutores.andInstagram.toLocaleLowerCase().indexOf(buscarTabelaPor) !== -1
     )
  }

  public getInstrutores(): void {

    this.instrutoreesService.getInstrutores().subscribe({
     next:(_Instrutores: Instrutor[]): void =>{
       this.Instrutores = _Instrutores;
       this.InstrutoresListados = this.Instrutores;
     },
     error:(error: any) => {
       this.toastrService.error('Erro ao localizar o Instrutor', 'Error!');
     },
    }).add(()=>this.spinner.hide())
 }


 openModal(event: any, template: TemplateRef<any>, InstrutorId: number): void {
  event.stopPropagation();
  this.InstrutorId = InstrutorId;
  this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
}

confirm(): void {
  this.modalRef?.hide();
  this.spinner.show();
  this.instrutoreesService.deleteInstrutores(this.InstrutorId).subscribe({
    next: (result: string)=>{
        this.toastrService.success('Instrutor Excluido.', 'sucesso!');
        this.getInstrutores();
    },
    error:(error: any)=>{
      this.toastrService.error(`Erro ao excluir o Instrutor. ${this.InstrutorId}`, 'Erro!');
    },
  }).add(()=> this.spinner.hide());
}

public decline(): void {
  this.modalRef?.hide();
}

cadEnvio(id: number): void{
  this.router.navigate([`/instrutores/cad/${id}`])
}
}

