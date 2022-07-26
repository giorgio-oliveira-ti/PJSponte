import { Instrutor } from './../../../../models/instrutor';
import { InstrutoresService } from './../../../../services/instrutores.service';
import { LiveService } from '@app/services/Live.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-bootstrap-spinner';
import { ToastrService } from 'ngx-toastr';
import { Live } from '@app/models/live';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-live-cad',
  templateUrl: './live-cad.component.html',
  styleUrls: ['./live-cad.component.css']
})
export class LiveCadComponent implements OnInit {

  liveId: number | undefined ;
  _Live = {} as Live;
  form!: FormGroup;
  modalRef?: BsModalRef;
  statusSalvar = 'post' ;
  public Instrutores: any = [];
  public selectedOptions: any = [];


  get f(): any {
    return this.form.controls;
  }

  public get bsconfigDatepicker(): any{
    return {
      isAnimated:true,
      adaptivePosition:true,
      ShowWeekNumbers: true,
      containerClass: 'theme-dark-blue',
      //dateInputFormat: 'DD/MM/YYYY hh:mm',
  }
}

get MEditar(): boolean{
  return this.statusSalvar == 'put';
}

constructor(
  private fb: FormBuilder,
  private localeService: BsLocaleService,
  private routerActive: ActivatedRoute,
  private router: Router,
  private spinner: NgxSpinnerService,
  private toastrService: ToastrService,
  private modalService: BsModalService,
  private liveService : LiveService,
  private instrutoresService : InstrutoresService,
) {
this.localeService.use('pt-br');
}

ngOnInit(): void {
  this.spinner.show();
  this.validation();
  this.carregarLive();
  this.carregarInstrutor();
}



public validation(): void{
  this.form = this.fb.group({
    nome: [''],
    descricao: [''],
    dataHoraInicio: [''],
    duracaoMinutos: [''],
    valorInscricao: [''],
    instrutorId:[''],
  });
}

public validarCss(formCampos: FormControl | AbstractControl):any{
  return {'is-invalid': formCampos.errors && formCampos.touched }
}

public resetForm(): void {
  this.form.reset();
  this.router.navigate([`Live/list`]);
}


public carregarInstrutor(): void{

  this.instrutoresService.getInstrutores().subscribe({
    next:(_Instrutores: Instrutor[]): void =>{
    this.Instrutores = _Instrutores;

    },
    error:(error: any) => {
      this.toastrService.error('Erro ao localizar o Instrutor', 'Error!');
    },
   }).add(()=>this.spinner.hide())

}

public carregarLive(): void{

  this.liveId = Number(this.routerActive.snapshot.paramMap.get('id'));

  this.spinner.hide();
  if(this.liveId == 0 ){
    this.statusSalvar = 'post';
  }else{
    this.statusSalvar = 'put';
    this.liveService.getLiveById(Number(this.liveId)).subscribe({
      next:(live: Live)=>{
       this._Live = {... live}
          this.form.patchValue(this._Live);
      },
      error:(error: any)=> {
       this.spinner.hide()
       this.toastrService.error('Falha Interna ao lado do servidor ');
     },
      complete:()=>{
       this.spinner.hide();
      }
  });
  }
}

public salvarLive(): void{

  if(this.form.valid){
    if(this.statusSalvar === 'post'){

      this._Live = {... this.form.value};
      this.liveService['post'](this._Live).subscribe({
          next:(LiveR: Live)=>{
          this.router.navigate([`Live/cad/${LiveR.id}`]);
          this.toastrService.success('Live  salvo com sucesso', 'Sucesso');
        },
        error:(error: any)=>{
          this.spinner.show();
          this.toastrService.error('Error ao salvar o Live','Erro');
        },
        complete:()=>{
          this.spinner.hide();
        },
    });

    }else{
      this._Live = {id: this._Live.id, ... this.form.value}
      this.liveService['put'](this._Live ).subscribe({
        next:()=>{
        this.toastrService.success('Live salvocom sucesso', 'Sucesso');
      },

      error:(error: any)=>{
        console.log(error);
        this.spinner.hide();
        this.toastrService.error('Error ao salvar o Instrutor','Erro');
      },
      complete:()=>{
        this.spinner.hide();
      },
    });
    }
  }
}


}
