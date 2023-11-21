import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { AnimaisService } from 'src/app/animais.service';
import { Animal } from 'src/app/Animal';
//import { TutoresService } from 'src/app/tutores.service';
//import { Tutor } from 'src/app/Tutor';

@Component({
  selector: 'app-animais',
  templateUrl: './animais.component.html',
  styleUrls: ['./animais.component.css']
})
export class AnimaisComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  //tutores: Array<Tutor> | undefined;

  constructor(private AnimaisService : AnimaisService/*, private TutoresService : TutoresService*/) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Animal';

    /*this.tutoresService.listar().subscribe(tutores => {
      this.tutores = tutores;
      if (this.tutores && this.tutores.length > 0) {
        this.formulario.get('tutorId')?.setValue(this.tutores[0].id);
      }
    });*/

    this.formulario = new FormGroup({
      nome: new FormControl(null),
      tutorId: new FormControl(null),
      especieAnimal: new FormControl(null),
      raca: new FormControl(null),
      idade: new FormControl(null),
      sexoDoAnimal: new FormControl(null),
      pesoAnimal: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const animal: Animal = this.formulario.value;
    const observer: Observer<Animal> = {
      next(_result): void {
        alert('Animal salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar animal!');
      },
      complete(): void {
      },
    };
    /*
    if (????) {
      this.carrosService.alterar(carro).subscribe(observer);
    } else {
    */
      this.AnimaisService.cadastrar(animal).subscribe(observer);
  }
}
