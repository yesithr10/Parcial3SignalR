using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Entidad;
using Logica;
using arriendos_sas.models;
using Microsoft.AspNetCore.SignalR;
using arriendos_sas.Hubs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace arriendos_sas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArriendoInmuebleController : ControllerBase
    {
        //Llamada al servicio de arriendo inmueble
        private readonly ArriendoInmuebleService _arriendoInmuebleService;
        private readonly IHubContext<ArriendoInmuebleHub> _hubContext;

        //Constructor de la clase
        public ArriendoInmuebleController(ArriendoContext arriendoContext, IHubContext<ArriendoInmuebleHub> hubContext)
        {
            _arriendoInmuebleService = new ArriendoInmuebleService(arriendoContext);
            _hubContext = hubContext;
        }

        // GET: api/<ArriendoInmuebleController>
        [HttpGet]
        public IEnumerable<ArriendoInmuebleViewModel> Get()
        {
            var arriendoInmuebles = _arriendoInmuebleService.ConsultarArriendosInmuebles().Select(result => new ArriendoInmuebleViewModel(result));
            return arriendoInmuebles;
        }

        // GET api/<ArriendoInmuebleController>/5
        [HttpGet("{id}")]
        public ArriendoInmuebleViewModel Get(string id)
        {
            var arriendoInmueble = _arriendoInmuebleService.ConsultarArriendosInmuebles().Where(result => result.IdentificacionArrendatario == id).Select(result => new ArriendoInmuebleViewModel(result)).FirstOrDefault();
            return arriendoInmueble;
        }

        // POST api/<ArriendoInmuebleController>
        [HttpPost]
        public async Task<ActionResult<ArriendoInmuebleViewModel>> Post(ArriendoInmuebleInputModel arriendoInput)
        {
            ArriendoInmueble arriendoInmueble = MapearArriendoInmueble(arriendoInput);
            RespuestaGuardarArriendoInmueble respuestaGuardarArriendoInmueble = _arriendoInmuebleService.GuardarArriendoInmueble(arriendoInmueble);
            var respuesta = respuestaGuardarArriendoInmueble;
            if (respuesta.Error)
            {
                return BadRequest(respuesta.Error);
            }

            await _hubContext.Clients.All.SendAsync("ArriendoNuevo", arriendoInmueble);

            return Ok(arriendoInmueble);
        }
        private ArriendoInmueble MapearArriendoInmueble(ArriendoInmuebleInputModel arriendoInput)
        {
            var arriendoInmueble = new ArriendoInmueble
            {
                MatriculaInmueble = arriendoInput.MatriculaInmueble,
                IdentificacionArrendatario = arriendoInput.IdentificacionArrendatario,
                NombreArrendatario = arriendoInput.NombreArrendatario,
                MesesAlquiler = arriendoInput.MesesAlquiler,
                ValorDeposito = arriendoInput.ValorDeposito
            };
            return arriendoInmueble;
        }
    }
}
