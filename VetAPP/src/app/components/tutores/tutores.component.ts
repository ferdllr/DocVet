import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { TutoresService } from 'src/app/tutores.service';
import { Tutor } from 'src/app/Tutor';
import { AnimaisService } from '../../animais.service';
import { Animal } from 'src/app/Animal';

@Component({
  selector: 'app-tutores',
  templateUrl: './tutores.component.html',
  styleUrls: ['./tutores.component.css']
})
export class TutoresComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  animais: Array<Animal> | undefined;

  constructor(private tutoresService : TutoresService, private AnimaisService : AnimaisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Tutor';

    this.AnimaisService.listar().subscribe(animais => {
      this.animais = animais;
      if (this.animais && this.animais.length > 0) {
        this.formulario.get('animalId')?.setValue(this.animais[0].animalId);
      }
    });

    this.formulario = new FormGroup({
      tutorId: new FormControl(null),
      nomeTutor: new FormControl(null),
      cpf: new FormControl(null),
      dataNascimento: new FormControl(null),
      telefone: new FormControl(null),
      email: new FormControl(null),
      animalId: new FormControl()
    })
  }
  enviarFormulario(): void {
    const tutor: Tutor = this.formulario.value;
    const observer: Observer<Tutor> = {
      next(_result): void {
        alert('Tutor salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar tutor!');
      },
      complete(): void {
      },
    };
    /*if (tutor.tutorId) {
       this.TutoresService.alterar(tutor).subscribe(observer);
    } else {
         this.TutoresService.cadastrar(tutor).subscribe(observer);
    }*/
      this.tutoresService.cadastrar(tutor).subscribe(observer);
  }
}
