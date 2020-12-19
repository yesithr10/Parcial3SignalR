using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;

namespace arriendos_sas.models
{
    public class InmuebleInputModel
    {
        public string MatriculaInmobiliaria { get; set; }
        public string Direccion { get; set; }
        public float ValorArriendo { get; set; }
    }
    public class InmuebleViewModel: InmuebleInputModel
    {
        public InmuebleViewModel (Inmueble inmueble)
        {
            MatriculaInmobiliaria = inmueble.MatriculaInmobiliaria;
            Direccion = inmueble.Direccion;
            ValorArriendo = inmueble.ValorArriendo;
        }
    }
}
