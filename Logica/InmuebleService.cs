using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class InmuebleService
    {
        private readonly ArriendoContext _arriendoContext;
        public InmuebleService(ArriendoContext arriendoContext)
        {
            _arriendoContext = arriendoContext;
        }

        //Metodo Guardar
        public RespuestaGuardarInmueble GuardarInmueble(Inmueble inmueble)
        {
            try
            {
                var buscarInmueble = _arriendoContext.Inmuebles.Find(inmueble.MatriculaInmobiliaria);
                if (buscarInmueble != null)
                {
                    return new RespuestaGuardarInmueble("El inmueble ha sido registrado anteriormente");
                }
                _arriendoContext.Inmuebles.Add(inmueble);
                _arriendoContext.SaveChanges();
                return new RespuestaGuardarInmueble(inmueble);
            }
            catch (System.Exception e)
            {
                return new RespuestaGuardarInmueble($"Error de la aplicación: {e.Message}");
            }
        }

        //Metodo consultar
        public List<Inmueble> ConsultarInmuebles()
        {
            List<Inmueble> inmuebles = _arriendoContext.Inmuebles.ToList();
            return inmuebles;
        }
    }
    public class RespuestaGuardarInmueble
    {
        public RespuestaGuardarInmueble(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public RespuestaGuardarInmueble(Inmueble inmueble)
        {
            Error = false;
            Inmueble = inmueble;
        }
        public Inmueble Inmueble { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
    }
}
