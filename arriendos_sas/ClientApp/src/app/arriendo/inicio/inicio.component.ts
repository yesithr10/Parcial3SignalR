import { Component, OnInit } from '@angular/core';
import { ArriendoInmuebleHubService } from 'src/app/services/arriendo-inmueble-hub.service';
import { ArriendoInmuebleService } from 'src/app/services/arriendo-inmueble.service';
import { InmuebleService } from 'src/app/services/inmueble.service';
import { ArriendoInmueble } from '../models/arriendo-inmueble';
import { Inmueble } from '../models/inmueble';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  busuqeda: string;
  inmuebles: Inmueble[];
  arriendos: ArriendoInmueble[] = [];
  constructor(
    private inmuebleService: InmuebleService,
    private arriendoInmuebleService: ArriendoInmuebleService,
    private arriendoSignalR: ArriendoInmuebleHubService
  ) { }

  ngOnInit() {
    this.consultarInmuebles();
    this.consultarArriendos();

    /**Iniciar conexión y subscribirse */
    this.arriendoSignalR.startConnection();
    this.arriendoSignalR.newArriendo.subscribe(arriendo => {
      this.arriendos.push(arriendo);
    });
  }

  consultarInmuebles() {
    this.inmuebleService.get().subscribe(result => {
      this.inmuebles = result;
    });
  }

  consultarArriendos() {
    this.arriendoInmuebleService.get().subscribe(result => {
      this.arriendos = result;
    });
  }
}
