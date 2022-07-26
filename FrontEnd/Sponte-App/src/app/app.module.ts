
import { NgModule,CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgxSpinnerModule } from "ngx-bootstrap-spinner";
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import {NgxCurrencyModule } from 'ngx-currency';
import { NgxMaskModule } from 'ngx-mask';
import { SelectDropDownModule } from 'ngx-select-dropdown'




import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

///Pipe

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { DateTimeForHoraPipe } from './helpers/DateTimeForHora.pipe';

///Componente Internos
import { NavComponent } from './shared/template/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { TitleComponent } from './shared/title/title.component';

import { InstrutoresComponent } from './components/cursos/instrutores/instrutores.component';
import { InstrutoresListComponent } from './components/cursos/instrutores/instrutores-list/instrutores-list.component';
import { InstrutoresCadComponent } from './components/cursos/instrutores/instrutores-cad/instrutores-cad.component';
import { InscritosComponent } from './components/cursos/inscritos/inscritos.component';
import { InscritosListComponent } from './components/cursos/inscritos/inscritos-list/inscritos-list.component';
import { InscritosCadComponent } from './components/cursos/inscritos/inscritos-cad/inscritos-cad.component';
import { LiveCadComponent } from './components/cursos/lives/live-cad/live-cad.component';
import { LivesComponent } from './components/cursos/lives/lives.component';
import { LiveListComponent } from './components/cursos/lives/live-list/live-list.component';


defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    DateTimeFormatPipe,
    DateTimeForHoraPipe,
    AppComponent,
    NavComponent,
    HomeComponent,
    TitleComponent,
    InstrutoresComponent,
    InstrutoresListComponent,
    InstrutoresCadComponent,
    InscritosComponent,
    InscritosListComponent,
    InscritosCadComponent,
    LivesComponent,
    LiveListComponent,
    LiveCadComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    CommonModule,
    NgxSpinnerModule,
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxCurrencyModule,
    NgxMaskModule.forRoot(),
    SelectDropDownModule,

  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
