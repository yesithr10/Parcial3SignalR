import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AgregarInmuebleComponent } from './Arriendo/agregar-inmueble/agregar-inmueble.component';
import { AgregarArriendoInmuebleComponent } from './Arriendo/agregar-arriendo-inmueble/agregar-arriendo-inmueble.component';
import { InicioComponent } from './Arriendo/inicio/inicio.component';

const routes: Routes = [
  { path: 'agregar-inmueble', component: AgregarInmuebleComponent },
  { path: 'agregar-arriendo', component: AgregarArriendoInmuebleComponent },
  { path: '', component: InicioComponent, pathMatch: 'full'},
  { path: '**', redirectTo: ''}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
