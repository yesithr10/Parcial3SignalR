import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ArriendoInmuebleService } from 'src/app/services/arriendo-inmueble.service';
import { ArriendoInmueble } from '../models/arriendo-inmueble';

@Component({
  selector: 'app-agregar-arriendo-inmueble',
  templateUrl: './agregar-arriendo-inmueble.component.html',
  styleUrls: ['./agregar-arriendo-inmueble.component.css']
})
export class AgregarArriendoInmuebleComponent implements OnInit {

  arriendoInmueble: ArriendoInmueble;
  formGroup: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private arriendoinmuebleService: ArriendoInmuebleService
  ) { }

  ngOnInit() {
    this.buildForm();
  }

  private buildForm() {
    this.arriendoInmueble = new ArriendoInmueble();
    this.arriendoInmueble.matriculaInmueble = '';
    this.arriendoInmueble.identificacionArrendatario = '';
    this.arriendoInmueble.nombreArrendatario = '';
    this.arriendoInmueble.mesesAlquiler = 0;
    this.arriendoInmueble.valorDeposito = 0;
  
    this.formGroup = this.formBuilder.group({
      matriculaInmueble: [this.arriendoInmueble.matriculaInmueble, Validators.required],
      identificacionArrendatario: [this.arriendoInmueble.identificacionArrendatario, Validators.required],
      nombreArrendatario: [this.arriendoInmueble.nombreArrendatario, Validators.required],
      mesesAlquiler: [this.arriendoInmueble.mesesAlquiler, Validators.required],
      valorDeposito: [this.arriendoInmueble.valorDeposito, Validators.required]
    })
  }

  get control() {
    return this.formGroup.controls;
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.arriendoInmueble = this.formGroup.value;
    this.arriendoinmuebleService.post(this.arriendoInmueble).subscribe(result => {
      alert("El arriendo del inmueble se ha registrado satisfactoriamente");
    });
  }

}
