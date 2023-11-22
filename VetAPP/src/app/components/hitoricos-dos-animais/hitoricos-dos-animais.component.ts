/*import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { HistoricosDosAnimaisService } from '../../historicos-dos-animais.service';
import { HistoricoDoAnimal } from 'src/app/HistoricoDoAnimal';
import { Prontuario } from 'src/app/Prontuario';

@Component({
  selector: 'app-estados-dos-animais',
  templateUrl: './estados-dos-animais.component.html',
  styleUrls: ['./estados-dos-animais.component.css']
})
export class HistoricosDosAnimaisComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  prontuarios: Array<Prontuario> | undefined;

  constructor(private historicosDosAnimaisService: HistoricosDosAnimaisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Histórico do Animal';

    this.formulario = new FormGroup({
      historicoDoAnimalId: new FormControl(null),
      prontuarioId: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    const historicoDoAnimal: HistoricoDoAnimal = this.formulario.value;
    const observer: Observer<HistoricoDoAnimal> = {
      next(_result): void {
        alert('Histórico do Animal salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar Histórico do Animal!');
      },
      complete(): void {
      },
    };

    this.historicosDosAnimaisService.cadastrar(historicoDoAnimal).subscribe(observer);
  }
}*/