import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { EstadosDosAnimaisService } from '../../estados-dos-animais.service';
import { EstadoDoAnimal } from 'src/app/EstadoDoAnimal';

@Component({
  selector: 'app-estados-dos-animais',
  templateUrl: './estados-dos-animais.component.html',
  styleUrls: ['./estados-dos-animais.component.css']
})
export class FuncionariosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private estadosDosAnimaisService : EstadosDosAnimaisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Estado do Animal';

    this.formulario = new FormGroup({
      estadoDoAnimalId: new FormControl(null),
      gravidadeDoAnimal: new FormControl(null),
      horario: new FormControl(null),
      descricao: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const estadoDoAnimal: EstadoDoAnimal = this.formulario.value;
    const observer: Observer<EstadoDoAnimal> = {
      next(_result): void {
        alert('Estado do Animal salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar Estado Do Animal!');
      },
      complete(): void {
      },
    };
    /*if (tutor.tutorId) {
       this.TutoresService.alterar(tutor).subscribe(observer);
    } else {
         this.TutoresService.cadastrar(tutor).subscribe(observer);
    }*/
      this.estadosDosAnimaisService.cadastrar(estadoDoAnimal).subscribe(observer);
  }
}
