import { Instrutor } from './instrutor';
export interface Live {
  id: number;
  nome: string;
  descricao: string;
  dataHoraInicio: Date;
  valorInscricao: number;
  instrutorId: number;
  instrutor: Instrutor;
}
