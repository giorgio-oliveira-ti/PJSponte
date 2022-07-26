
import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Live } from '@app/models/live';
import { LiveService } from '@app/services/Live.service';
import { NgxSpinnerService } from 'ngx-bootstrap-spinner';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-live-list',
  templateUrl: './live-list.component.html',
  styleUrls: ['./live-list.component.css']
})
export class LiveListComponent implements OnInit {

  modalRef?: BsModalRef;
  toastr: any;
  public Live: any = [];
  public LiveListados: any = [];
  public LiveId = 0;
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
  private liveService: LiveService
  ) { }

ngOnInit():void {
  this.spinner.show();
  this.getLive();
}

public get BuscarList(): string {
  return this._BuscarList;
}

public set BuscarList(value: string ){
  this._BuscarList = value;
 this.LiveListados = this.BuscarList ?  this.buscarListaLive(this.BuscarList) : this.Live  ;
}

public buscarListaLive(buscarTabelaPor: string): any {
  buscarTabelaPor = buscarTabelaPor.toLocaleLowerCase();
  return this.LiveListados.filter(
    (Lives: { nome: string; dataHoraInicio: string; duracaoMinutos: string;
    }) => Lives.nome.toLocaleLowerCase().indexOf(buscarTabelaPor) !== -1 ||
    Lives.dataHoraInicio.toLocaleLowerCase().indexOf(buscarTabelaPor) !== -1
   )
}

public getLive(): void {

  this.liveService.getLive().subscribe({
   next:(_Live: Live[]): void =>{
     this.Live = _Live;
     this.LiveListados = this.Live;
   },
   error:(error: any) => {
     this.toastrService.error('Erro ao localizar o Live', 'Error!');
   },
  }).add(()=>this.spinner.hide())
}

openModal(event: any, template: TemplateRef<any>, LiveId: number): void {
  event.stopPropagation();
  this.LiveId = LiveId;
  this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
}

confirm(): void {
  this.modalRef?.hide();
  this.spinner.show();
  this.liveService.deleteLive(this.LiveId).subscribe({
    next: (result: string)=>{
        this.toastrService.success('Live Excluido.', 'sucesso!');
        this.getLive();
    },
    error:(error: any)=>{
      this.toastrService.error(`Erro ao excluir o Live. ${this.LiveId}`, 'Erro!');
    },
  }).add(()=> this.spinner.hide());
}

public decline(): void {
  this.modalRef?.hide();
}

cadEnvio(id: number): void{
  this.router.navigate([`/Live/cad/${id}`])
}




}
