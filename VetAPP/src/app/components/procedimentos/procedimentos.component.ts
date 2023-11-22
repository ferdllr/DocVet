import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Procedimento } from 'src/app/Procedimento';
import { ProcedimentosService } from '../../procedimentos.service';

@Component({
  selector: 'app-procedimentos',
  templateUrl: './procedimentos.component.html',
  styleUrls: ['./procedimentos.component.css']
})
export class ProcedimentosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private procedimentosService : ProcedimentosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Procedimento';

    this.formulario = new FormGroup({
      procedimentoId: new FormControl(null),
      nome: new FormControl(null),
      tipoProcedimento: new FormControl(null),
      descricao: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const procedimento: Procedimento = this.formulario.value;
    const observer: Observer<Procedimento> = {
      next(_result): void {
        alert('Procedimento salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar procedimento!');
      },
      complete(): void {
      },
    };
    /*if (tutor.tutorId) {
       this.TutoresService.alterar(tutor).subscribe(observer);
    } else {
         this.TutoresService.cadastrar(tutor).subscribe(observer);
    }*/
      this.procedimentosService.cadastrar(procedimento).subscribe(observer);
  }
}
