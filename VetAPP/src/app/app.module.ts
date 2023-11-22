import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AnimaisService } from './animais.service';
import { AnimaisComponent } from './components/animais/animais.component';

import { TutoresService } from './tutores.service';
import { TutoresComponent } from './components/tutores/tutores.component';

import { ProcedimentosComponent } from './components/procedimentos/procedimentos.component';
import { ProcedimentosService } from './procedimentos.service';

import { FuncionariosService } from './funcionarios.service';
import { FuncionariosComponent } from './components/funcionarios/funcionarios.component';

import { AlimentacoesService } from './alimentacoes.service';
import { AlimentacoesComponent } from './components/alimentacoes/alimentacoes.component';

import { EstadosDosAnimaisService } from './estados-dos-animais.service';
import { EstadosDosAnimaisComponent } from './components/estados-dos-animais/estados-dos-animais.component';

import { ExamesComponent } from './components/exames/exames.component';
import { ExamesService } from './exames.service';
import { MedicamentosComponent } from './components/medicamentos/medicamentos.component';

import { VacinasComponent } from './components/vacinas/vacinas.component';
import { VacinasService } from './vacinas.service';
import { ProntuariosComponent } from './components/prontuarios/prontuarios.component';
import { ProntuariosService } from './prontuarios.service';
import { HitoricosDosAnimaisComponent } from './components/hitoricos-dos-animais/hitoricos-dos-animais.component';

@NgModule({
  declarations: [
    AppComponent,
    AnimaisComponent,
    TutoresComponent,
    ProcedimentosComponent,
    FuncionariosComponent,
    AlimentacoesComponent,
    EstadosDosAnimaisComponent,
    ExamesComponent,
    MedicamentosComponent,
    VacinasComponent,
    ProntuariosComponent,
    HitoricosDosAnimaisComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    HttpClientModule,
    AnimaisService,
    TutoresService,
    ProcedimentosService,
    FuncionariosService,
    AlimentacoesService,
    EstadosDosAnimaisService,
    ExamesService,
    VacinasService,
    ProntuariosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
