import { Animal } from './Animal';

export class Vacina{
    vacinaId: number = 0;
    nome: string = '';
    dataVacinacao: Date | undefined;
    veterinarioResponsavel: string = '';
    lote: string = '';
    proximaDataReforco: Date | undefined;
    animal: Animal | undefined;
}