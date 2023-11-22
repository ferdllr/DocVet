import { EstadoDoAnimal } from './EstadoDoAnimal';
import { Medicamento } from './Medicamento';

export class Prontuario{
    prontuarioId: number = 0;
    data: Date | undefined;
    estadoDoAnimal: EstadoDoAnimal[] | undefined;
    medicameto: Medicamento[] | undefined;
}