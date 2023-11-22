import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Medicamento } from 'src/app/Medicamento';
import { MedicamentosService } from '../../medicamentos.service';

@Component({
  selector: 'app-medicamentos',
  templateUrl: './medicamentos.component.html',
  styleUrls: ['./medicamentos.component.css']
})
export class MedicamentosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private medicamentosService: MedicamentosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Medicamento';

    this.formulario = new FormGroup({
      medicamentoId: new FormControl(null),
      nome: new FormControl(null),
      tipoMedicamento: new FormControl(null),
      miligrama: new FormControl(null),
      tarjaMedicamento: new FormControl(null),
      ciclo: new FormControl(null),
    });
  }

  enviarFormulario(): void {
    const medicamento: Medicamento = this.formulario.value;
    const observer: Observer<Medicamento> = {
      next(_result): void {
        alert('Medicamento salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar medicamento!');
      },
      complete(): void {
      },
    };

    this.medicamentosService.cadastrar(medicamento).subscribe(observer);
  }
}
