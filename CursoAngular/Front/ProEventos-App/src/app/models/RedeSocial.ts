import { Evento } from "./Evento";
import { Palestrante } from "./Palestrante";

export interface RedeSocial {

   id: number;
   nome: string;
   URL: string;
   eventoId? : number;
   palestranteId? : number ;
}
