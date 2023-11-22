import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Exame } from 'src/app/Exame';
import { ExamesService } from '../../exames.service';

@Component({
  selector: 'app-exames',
  templateUrl: './exames.component.html',
  styleUrls: ['./exames.component.css']
})
export class ExamesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private examesService: ExamesService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Exame';

    this.formulario = new FormGroup({
      exameId: new FormControl(null),
      tipoExame: new FormControl(null),
      data: new FormControl(null),
      observacao: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    const exame: Exame = this.formulario.value;
    const observer: Observer<Exame> = {
      next(_result): void {
        alert('Exame salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar exame!');
      },
      complete(): void {
      },
    };

    this.examesService.cadastrar(exame).subscribe(observer);
  }
}
