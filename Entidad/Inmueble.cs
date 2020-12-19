using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Inmueble
    {
        [Key]
        public string MatriculaInmobiliaria { get; set; }
        public string Direccion { get; set; }
        public float ValorArriendo { get; set; }
    }
}
