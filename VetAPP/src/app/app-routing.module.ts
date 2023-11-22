import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnimaisComponent } from './components/animais/animais.component';
import { TutoresComponent } from './components/tutores/tutores.component';
import { ProcedimentosComponent } from './components/procedimentos/procedimentos.component';
import { FuncionariosComponent } from './components/funcionarios/funcionarios.component';
import { AlimentacoesComponent } from './components/alimentacoes/alimentacoes.component';

const routes: Routes = [
  { path: 'animais', component:  AnimaisComponent},
  { path: 'tutores', component:  TutoresComponent},
  { path: 'procedimentos', component:  ProcedimentosComponent},
  { path: 'funcionarios', component:  FuncionariosComponent},
  { path: 'alimentacoes', component:  AlimentacoesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
