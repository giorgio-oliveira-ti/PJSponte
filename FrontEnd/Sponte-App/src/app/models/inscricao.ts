import { Inscrito } from "./inscrito";
import { Live } from "./live";

export interface Inscricao {
  id: number;
  valorInscricao: number;
  dataVencimento: Date;
  statusPagamento: boolean;
  liveId: number;
  inscritoId: number;
  live: Live;
  inscrito: Inscrito;
}
