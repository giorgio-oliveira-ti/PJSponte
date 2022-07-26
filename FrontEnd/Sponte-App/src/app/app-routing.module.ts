import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';



import { HomeComponent } from './components/home/home.component';
import { InstrutoresListComponent } from './components/cursos/instrutores/instrutores-list/instrutores-list.component';
import { InstrutoresComponent } from './components/cursos/instrutores/instrutores.component';
import { InstrutoresCadComponent } from './components/cursos/instrutores/instrutores-cad/instrutores-cad.component';
import { InscritosComponent } from './components/cursos/inscritos/inscritos.component';
import { InscritosListComponent } from './components/cursos/inscritos/inscritos-list/inscritos-list.component';
import { InscritosCadComponent } from './components/cursos/inscritos/inscritos-cad/inscritos-cad.component';

import { LivesComponent } from './components/cursos/lives/lives.component';
import { LiveListComponent } from './components/cursos/lives/live-list/live-list.component';
import { LiveCadComponent } from './components/cursos/lives/live-cad/live-cad.component';


const routes: Routes = [
  { path:'instrutores', component: InstrutoresComponent,
    children:[
    { path:'list', component: InstrutoresListComponent },
    { path:'cad', component: InstrutoresCadComponent },
    { path:'cad/:id', component: InstrutoresCadComponent }
  ]
},
{ path:'Inscritos', component: InscritosComponent,
children:[
  { path:'list', component: InscritosListComponent },
  { path:'cad', component: InscritosCadComponent },
  { path:'cad/:id', component: InscritosCadComponent }
]
},
{ path:'Live', component: LivesComponent,
children:[
  { path:'list', component: LiveListComponent },
  { path:'cad', component: LiveCadComponent },
  { path:'cad/:id', component: LiveCadComponent }
]
},
  {path:'home', component:HomeComponent},
  {path:'', redirectTo: 'home', pathMatch:'full'},
  {path:'**', redirectTo: 'home', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
