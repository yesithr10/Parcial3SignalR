using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;

namespace arriendos_sas.models
{
    public class ArriendoInmuebleInputModel
    {
        public string MatriculaInmueble { get; set; }
        public string IdentificacionArrendatario { get; set; }
        public string NombreArrendatario { get; set; }
        public int MesesAlquiler { get; set; }
        public float ValorDeposito { get; set; }
    }
    public class ArriendoInmuebleViewModel: ArriendoInmuebleInputModel
    {
        public ArriendoInmuebleViewModel(ArriendoInmueble arriendoInmueble)
        {
            MatriculaInmueble = arriendoInmueble.MatriculaInmueble;
            IdentificacionArrendatario = arriendoInmueble.IdentificacionArrendatario;
            NombreArrendatario = arriendoInmueble.NombreArrendatario;
            MesesAlquiler = arriendoInmueble.MesesAlquiler;
            ValorDeposito = arriendoInmueble.ValorDeposito;
        }
    }
}
