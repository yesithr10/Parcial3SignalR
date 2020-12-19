
import { EventEmitter, Injectable, Output } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { ArriendoInmueble } from '../arriendo/models/arriendo-inmueble';


@Injectable({
  providedIn: 'root'
})
export class ArriendoInmuebleHubService {

  private hubConnection: signalR.HubConnection;

  /**
   * Aquí se van a subscribir todos los que quieran saber cuando se registra un nuevo inmueble
   */
  @Output() newArriendo = new EventEmitter<ArriendoInmueble>();

  constructor() { }

  startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder().withUrl('/routehub').build();

    this.hubConnection.start()
      .then(() => {
        console.log('Connection Started');
        this.onNewArriendo();
      })
      .catch((err) => {
        console.log('Error: ' + err);
        setTimeout(() => this.startConnection(), 5000);
      })
  }

  onNewArriendo() {
    this.hubConnection.on('ArriendoNuevo', (arriendo) => {
      this.newArriendo.emit(arriendo);
    })
  }
}
