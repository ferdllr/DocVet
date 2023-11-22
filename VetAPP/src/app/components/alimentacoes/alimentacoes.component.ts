import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { AnimaisService } from 'src/app/animais.service';
import { Animal } from 'src/app/Animal';
import { Alimentacao } from 'src/app/Alimentacao';
import { AlimentacoesService } from '../../alimentacoes.service';

@Component({
  selector: 'app-alimentacoes',
  templateUrl: './alimentacoes.component.html',
  styleUrls: ['./alimentacoes.component.css']
})
export class AlimentacoesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  animais: Array<Animal> | undefined;

  constructor(private alimentacoesService : AlimentacoesService, private animaisService : AnimaisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Alimentacao';

    this.animaisService.listar().subscribe(animais => {
      this.animais = animais;
      if (this.animais && this.animais.length > 0) {
        this.formulario.get('animalId')?.setValue(this.animais[0].animalId);
      }
    });

    this.formulario = new FormGroup({
      alimentacaoId: new FormControl(null),
      dataAlimentacao : new FormControl(null),
      horaAlimentacao : new FormControl(null),
      tipoAlimento : new FormControl(null),
      quantidadeFornecida : new FormControl(null),
      frequenciaRefeicoes : new FormControl(null),
      observacoes : new FormControl(null),
      animalId : new FormControl(null)
      
    })
  }
  enviarFormulario(): void {
    const alimentacao: Alimentacao = this.formulario.value;
    const observer: Observer<Alimentacao> = {
      next(_result): void {
        alert('Alimentacao salva com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar alimentacao!');
      },
      complete(): void {
      },
    };
    /*
    if (????) {
      this.carrosService.alterar(carro).subscribe(observer);
    } else {
    */
      this.alimentacoesService.cadastrar(alimentacao).subscribe(observer);
  }
}
