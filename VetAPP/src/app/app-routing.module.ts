import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnimaisComponent } from './components/animais/animais.component';

const routes: Routes = [
  { path: 'animais', component:  AnimaisComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
