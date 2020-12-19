import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InmuebleService } from 'src/app/services/inmueble.service';
import { Inmueble } from '../models/inmueble';

@Component({
  selector: 'app-agregar-inmueble',
  templateUrl: './agregar-inmueble.component.html',
  styleUrls: ['./agregar-inmueble.component.css']
})
export class AgregarInmuebleComponent implements OnInit {

  inmueble: Inmueble;
  formGroup: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private inmuebleService: InmuebleService
  ) { }

  ngOnInit() {
    this.buildForm();
  }

  private buildForm() {
    this.inmueble = new Inmueble();
    this.inmueble.matriculaInmobiliaria = '';
    this.inmueble.direccion = '';
    this.inmueble.valorArriendo = 0;

    this.formGroup = this.formBuilder.group({
      matriculaInmobiliaria: [this.inmueble.matriculaInmobiliaria, Validators.required],
      direccion: [this.inmueble.direccion, Validators.required],
      valorArriendo: [this.inmueble.valorArriendo, Validators.required]
    });
  }

  get control() {
    return this.formGroup.controls;
  }

  onSubmit() {
    if (this.formGroup.invalid){
      return;
    }
    this.add();
  }

  add() {
    this.inmueble = this.formGroup.value;
    this.inmuebleService.post(this.inmueble).subscribe(result => {
      alert("El inmueble se ha registrado satisfactoriamente");
    });
  }

}
