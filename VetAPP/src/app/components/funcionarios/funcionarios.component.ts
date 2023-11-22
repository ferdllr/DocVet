import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { FuncionariosService } from '../../funcionarios.service';
import { Funcionario } from 'src/app/Funcionario';

@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css']
})
export class FuncionariosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private funcionariosService : FuncionariosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Funcionario';

    this.formulario = new FormGroup({
      funcionarioId: new FormControl(null),
      nome: new FormControl(null),
      cpf: new FormControl(null),
      telefone: new FormControl(null),      
      email: new FormControl(null),
      tipoFuncionario: new FormControl()
    })
  }
  enviarFormulario(): void {
    const funcionario: Funcionario = this.formulario.value;
    const observer: Observer<Funcionario> = {
      next(_result): void {
        alert('Funcionario salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar funcionario!');
      },
      complete(): void {
      },
    };
    /*if (tutor.tutorId) {
       this.TutoresService.alterar(tutor).subscribe(observer);
    } else {
         this.TutoresService.cadastrar(tutor).subscribe(observer);
    }*/
      this.funcionariosService.cadastrar(funcionario).subscribe(observer);
  }
}
