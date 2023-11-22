import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { ProntuariosService } from 'src/app/prontuarios.service';
import { Prontuario } from 'src/app/Prontuario';
import { EstadoDoAnimal } from 'src/app/EstadoDoAnimal';
import { Medicamento } from 'src/app/Medicamento';
import { EstadosDosAnimaisService } from '../../estados-dos-animais.service';
import { MedicamentosService } from 'src/app/medicamentos.service';

@Component({
  selector: 'app-prontuarios',
  templateUrl: './prontuarios.component.html',
  styleUrls: ['./prontuarios.component.css']
})
export class ProntuariosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  estadosDosAnimais: Array<EstadoDoAnimal> | undefined;
  medicamentos: Array<Medicamento> | undefined;

  constructor(private prontuariosService: ProntuariosService, private estadosDosAnimaisService: EstadosDosAnimaisService, private medicamentosService: MedicamentosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Prontuário';

    this.formulario = new FormGroup({
      prontuarioId: new FormControl(null),
      data: new FormControl(null),
      estadoDoAnimalId: new FormControl(null),
      medicamentoId: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    const prontuario: Prontuario = this.formulario.value;
    const observer: Observer<Prontuario> = {
      next(_result): void {
        alert('Prontuário salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar prontuário!');
      },
      complete(): void {
      },
    };

    this.prontuariosService.cadastrar(prontuario).subscribe(observer);
  }
}
