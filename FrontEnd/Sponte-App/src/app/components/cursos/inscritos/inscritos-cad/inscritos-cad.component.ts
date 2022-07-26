import { InscritosService } from './../../../../services/Inscritos.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-bootstrap-spinner';
import { ToastrService } from 'ngx-toastr';
import { Inscrito } from '@app/models/inscrito';


@Component({
  selector: 'app-inscritos-cad',
  templateUrl: './inscritos-cad.component.html',
  styleUrls: ['./inscritos-cad.component.css']
})
export class InscritosCadComponent implements OnInit {

  inscritoId: number | undefined ;
  _Inscrito = {} as Inscrito;
  form!: FormGroup;
  modalRef?: BsModalRef;
  statusSalvar = 'post' ;

  get f(): any {
    return this.form.controls;
  }

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
  private InscritosService: InscritosService

) {
this.localeService.use('pt-br');
}


ngOnInit(): void {
  this.spinner.show();
  this.validation();
  this.carregarInscrito();
}

public validarCss(formCampos: FormControl | AbstractControl):any{
  return {'is-invalid': formCampos.errors && formCampos.touched }
}

public validation(): void{
  this.form = this.fb.group({
    nome: [''],
    dataNascimento: [''],
    email: [''],
    endInstagram: [''],
  });
}

public resetForm(): void {
  this.form.reset();
  this.router.navigate([`Inscritos/list`]);
}


public carregarInscrito(): void{

  this.inscritoId = Number(this.routerActive.snapshot.paramMap.get('id'));

  this.spinner.hide();
  if(this.inscritoId == 0 ){
    this.statusSalvar = 'post';
  }else{
    this.statusSalvar = 'put';
    this.InscritosService.getInscritoById(Number(this.inscritoId)).subscribe({
      next:(inscrito: Inscrito)=>{
       this._Inscrito = {... inscrito}
       console.log(this._Inscrito );
          this.form.patchValue(this._Inscrito);
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

public salvarInscrito(): void{

  if(this.form.valid){
    if(this.statusSalvar === 'post'){

      this._Inscrito = {... this.form.value};
      this.InscritosService['post'](this._Inscrito).subscribe({
          next:(inscritoR: Inscrito)=>{
          this.router.navigate([`Inscritos/cad/${inscritoR.id}`]);
          this.toastrService.success('Inscrito  salvocom sucesso', 'Sucesso');
        },
        error:(error: any)=>{
          this.spinner.show();
          this.toastrService.error('Error ao salvar o Inscrito','Erro');
        },
        complete:()=>{
          this.spinner.hide();
        },
    });

    }else{
      this._Inscrito = {id: this._Inscrito.id, ... this.form.value}
      this.InscritosService['put'](this._Inscrito ).subscribe({
        next:()=>{
        this.toastrService.success('Inscrito salvo com Sucesso', 'Sucesso');
      },

      error:(error: any)=>{
        console.log(error);
        this.spinner.hide();
        this.toastrService.error('Error ao salvar o Inscrito','Error');
      },
      complete:()=>{
        this.spinner.hide();
      },
    });
    }
  }
}
}
