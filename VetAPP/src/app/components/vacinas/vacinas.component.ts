import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { VacinasService } from 'src/app/vacinas.service';
import { Vacina } from 'src/app/Vacina';
import { AnimaisService } from '../../animais.service';
import { Animal } from 'src/app/Animal';

@Component({
  selector: 'app-vacinas',
  templateUrl: './vacinas.component.html',
  styleUrls: ['./vacinas.component.css']
})
export class VacinasComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  animais: Array<Animal> | undefined;

  constructor(private vacinasService: VacinasService, private animaisService: AnimaisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Vacina';

    this.animaisService.listar().subscribe(animais => {
      this.animais = animais;
      if (this.animais && this.animais.length > 0) {
        this.formulario.get('animal')?.setValue(this.animais[0]);
      }
    });

    this.formulario = new FormGroup({
      vacinaId: new FormControl(null),
      nome: new FormControl(null),
      dataVacinacao: new FormControl(null),
      veterinarioResponsavel: new FormControl(null),
      lote: new FormControl(null),
      proximaDataReforco: new FormControl(null),
      animalId: new FormControl()
    });
  }

  enviarFormulario(): void {
    const vacina: Vacina = this.formulario.value;
    const observer: Observer<Vacina> = {
      next(_result): void {
        alert('Vacina salva com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar vacina!');
      },
      complete(): void {
      },
    };

    this.vacinasService.cadastrar(vacina).subscribe(observer);
  }
}
