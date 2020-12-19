using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class ArriendoInmuebleService
    {
        private readonly ArriendoContext _arriendoContext;
        public ArriendoInmuebleService(ArriendoContext arriendoContext)
        {
            _arriendoContext = arriendoContext;
        }

        //Metodo Guardar
        public RespuestaGuardarArriendoInmueble GuardarArriendoInmueble(ArriendoInmueble arriendoInmueble)
        {
            try
            {
                var buscarArriendo = _arriendoContext.ArriendosInmuebles.Find(arriendoInmueble.MatriculaInmueble);
                if (buscarArriendo != null)
                {
                    return new RespuestaGuardarArriendoInmueble("El arriendo ha sido registrado anteriormente");
                }
                _arriendoContext.ArriendosInmuebles.Add(arriendoInmueble);
                _arriendoContext.SaveChanges();
                return new RespuestaGuardarArriendoInmueble(arriendoInmueble);
            }
            catch (System.Exception e)
            {
                return new RespuestaGuardarArriendoInmueble($"Error de la aplicación: {e.Message}");
            }
        }

        //Metodo consultar
        public List<ArriendoInmueble> ConsultarArriendosInmuebles()
        {
            List<ArriendoInmueble> arriendoInmuebles = _arriendoContext.ArriendosInmuebles.ToList();
            return arriendoInmuebles;
        }
    }
    public class RespuestaGuardarArriendoInmueble
    {
        public RespuestaGuardarArriendoInmueble(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public RespuestaGuardarArriendoInmueble(ArriendoInmueble arriendoInmueble)
        {
            Error = false;
            ArriendoInmueble = arriendoInmueble;
        }
        public ArriendoInmueble ArriendoInmueble { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
    }
}
