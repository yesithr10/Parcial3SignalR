using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Datos;
using arriendos_sas.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace arriendos_sas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmuebleController : ControllerBase
    {
        //Llamada al servicio de inmueble
        private readonly InmuebleService _inmuebleService;

        //Constructor de la clase
        public InmuebleController(ArriendoContext arriendoContext)
        {
            _inmuebleService = new InmuebleService(arriendoContext);
        }
        // GET: api/<InmuebleController>
        [HttpGet]
        public IEnumerable<InmuebleViewModel> Get()
        {
            var inmuebles = _inmuebleService.ConsultarInmuebles().Select(result => new InmuebleViewModel(result));
            return inmuebles;
        }

        // GET api/<InmuebleController>/5
        [HttpGet("{id}")]
        public InmuebleViewModel Get(string id)
        {
            var inmueble = _inmuebleService.ConsultarInmuebles().Where(result => result.MatriculaInmobiliaria == id).Select(result => new InmuebleViewModel(result)).FirstOrDefault();
            return inmueble;
        }

        // POST api/<InmuebleController>
        [HttpPost]
        public ActionResult<InmuebleViewModel> Post(InmuebleInputModel inmuebleInput)
        {
            Inmueble inmueble = MapearInmueble(inmuebleInput);
            RespuestaGuardarInmueble respuestaGuardarInmueble = _inmuebleService.GuardarInmueble(inmueble);
            var respuesta = respuestaGuardarInmueble;
            if (respuesta.Error)
            {
                return BadRequest(respuesta.Error);
            }
            return Ok(respuesta.Inmueble);
        }
        private Inmueble MapearInmueble(InmuebleInputModel inmuebleInput)
        {
            var inmueble = new Inmueble
            {
                MatriculaInmobiliaria = inmuebleInput.MatriculaInmobiliaria,
                Direccion = inmuebleInput.Direccion,
                ValorArriendo = inmuebleInput.ValorArriendo
            };
            return inmueble;
        }
    }
}
