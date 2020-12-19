import { Pipe, PipeTransform } from '@angular/core';
import { Inmueble } from '../arriendo/models/inmueble';

@Pipe({
  name: 'filtroInmueble'
})
export class FiltroInmueblePipe implements PipeTransform {

  transform(inmuebles: Inmueble[], inmuebleBuscado: string): any {
    if (inmuebleBuscado == null) return inmuebles;
    return inmuebles.filter(p => 
      p.matriculaInmobiliaria.toLowerCase()
      .indexOf(inmuebleBuscado.toLowerCase()) !== -1);
  }

}
