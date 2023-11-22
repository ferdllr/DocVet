import { Animal } from './Animal';

export class Alimentacao{
    alimentacaoId: number = 0;
    dataAlimentacao: Date;
    horaAlimentacao: string = '';
    tipoAlimento: string = '';
    quantidadeFornecida: number = 0;
    frequenciaRefeicoes: string = '';
    observacoes: string = '';
    animal: Animal | undefined;

    constructor(alimentacaoId: number, dataAlimentacao: Date, horaAlimentacao: string) {
        this.alimentacaoId = alimentacaoId;
        this.dataAlimentacao = dataAlimentacao;
        this.horaAlimentacao = horaAlimentacao;
    }
}