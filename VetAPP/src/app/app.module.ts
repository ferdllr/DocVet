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

@NgModule({
  declarations: [
    AppComponent,
    AnimaisComponent
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
    HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
