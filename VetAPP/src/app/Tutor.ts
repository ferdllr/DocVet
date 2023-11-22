import { Animal } from './Animal';

export class Tutor {
    tutorId: number;
    nomeTutor: string = '';
    cpf: string = '';
    dataNascimento: Date;
    telefone: string = '';
    email: string = '';
    animais: Animal[];

    constructor(tutorId: number, dataNascimento: Date) {
        this.tutorId = tutorId;
        this.dataNascimento = dataNascimento;
        this.animais = [];
    }
}