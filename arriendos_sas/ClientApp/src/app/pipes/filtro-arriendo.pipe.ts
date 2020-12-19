import { Pipe, PipeTransform } from '@angular/core';
import { ArriendoInmueble } from '../arriendo/models/arriendo-inmueble';

@Pipe({
  name: 'filtroArriendo'
})
export class FiltroArriendoPipe implements PipeTransform {

  transform(arriendos: ArriendoInmueble[], arriendoBuscado: string): any {
    if (arriendoBuscado == null) return arriendos;
    return arriendos.filter(p => 
      p.matriculaInmueble.toLowerCase()
      .indexOf(arriendoBuscado.toLowerCase()) !== -1);
    
  }

}
