import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-bootstrap-spinner';
import { ToastrService } from 'ngx-toastr';
import { Instrutor } from '@app/models/instrutor';
import { InstrutoresService } from './../../../../services/instrutores.service';


@Component({
  selector: 'app-instrutores-cad',
  templateUrl: './instrutores-cad.component.html',
  styleUrls: ['./instrutores-cad.component.css']
})
export class InstrutoresCadComponent implements OnInit {

  instrutorId: number | undefined ;
  _Instrutor = {} as Instrutor;
  form!: FormGroup;
  modalRef?: BsModalRef;
  vrDadosInstrutor: string | undefined ;
  statusSalvar = 'post' ;



///retornando metodo controls para validação.////
get f(): any {
  return this.form.controls;
}

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
      private InstrutoresService : InstrutoresService
  ) {
    this.localeService.use('pt-br');
  }

  ngOnInit(): void {
    this.spinner.show();
    this.validation();
    this.carregarInstrutor();
  }


  public validarCss(formCampos: FormControl | AbstractControl):any{
    return {'is-invalid': formCampos.errors && formCampos.touched }
  }

  public resetForm(): void {
    this.form.reset();
    this.router.navigate([`instrutores/list`]);
 }


  public validation(): void{
    this.form = this.fb.group({
      nome: [''],
      dataNascimento: [''],
      email: [''],
      andInstagram: [''],
    });
  }


  public carregarInstrutor(): void{

    this.instrutorId = Number(this.routerActive.snapshot.paramMap.get('id'));

    this.spinner.hide();
    if(this.instrutorId == 0 ){
      this.statusSalvar = 'post';
    }else{
      this.statusSalvar = 'put';
      this.InstrutoresService.getInstrutoresById(Number(this.instrutorId)).subscribe({
        next:(intrutor: Instrutor)=>{
         this._Instrutor = {... intrutor}
            this.form.patchValue(this._Instrutor);
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

  public salvarInstrutor(): void{

    if(this.form.valid){
      if(this.statusSalvar === 'post'){

        this._Instrutor = {... this.form.value};
        this.InstrutoresService['post'](this._Instrutor).subscribe({
            next:(InstrutorR: Instrutor)=>{
            this.router.navigate([`instrutores/cad/${InstrutorR.id}`]);
            this.toastrService.success('Instrutor  salvo com sucesso', 'Sucesso');
          },
          error:(error: any)=>{
            this.spinner.show();
            this.toastrService.error('Error ao salvar o Instrutor','Erro');
          },
          complete:()=>{
            this.spinner.hide();
          },
      });

      }else{
        this._Instrutor = {id: this._Instrutor.id, ... this.form.value}
        this.InstrutoresService['put'](this._Instrutor ).subscribe({
          next:()=>{
          this.toastrService.success('Instrutor salvo com sucesso', 'Sucesso');
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
