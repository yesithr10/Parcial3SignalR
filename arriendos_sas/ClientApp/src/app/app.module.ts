import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { InmuebleService } from './services/inmueble.service';
import { ArriendoInmuebleService } from './services/arriendo-inmueble.service';
import { NavbarComponent } from './Arriendo/navbar/navbar.component';
import { FooterComponent } from './Arriendo/footer/footer.component';
import { InicioComponent } from './Arriendo/inicio/inicio.component';
import { AgregarInmuebleComponent } from './Arriendo/agregar-inmueble/agregar-inmueble.component';
import { AgregarArriendoInmuebleComponent } from './Arriendo/agregar-arriendo-inmueble/agregar-arriendo-inmueble.component';
import { FiltroArriendoPipe } from './pipes/filtro-arriendo.pipe';
import { FiltroInmueblePipe } from './pipes/filtro-inmueble.pipe';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    InicioComponent,
    AgregarInmuebleComponent,
    AgregarArriendoInmuebleComponent,
    FiltroArriendoPipe,
    FiltroInmueblePipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
    ]),
    AppRoutingModule
  ],
  providers: [InmuebleService, ArriendoInmuebleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
