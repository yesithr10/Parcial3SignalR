using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class ArriendoInmueble
    {
        [Key]
        public string MatriculaInmueble { get; set; }
        public string IdentificacionArrendatario { get; set; }
        public string NombreArrendatario { get; set; }
        public int MesesAlquiler { get; set; }
        public float ValorDeposito { get; set; }
    }
}
