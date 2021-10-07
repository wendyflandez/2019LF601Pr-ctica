using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2019LF601Práctica.Models;

namespace _2019LF601Práctica.Controllers
{
    [ApiController]
    public class estados_reservasController : ControllerBase
    {
        private readonly _2019LF601Context _contexto;
        public estados_reservasController(_2019LF601Context miContexto)
        {
            this._contexto = miContexto;

        }
        [HttpGet]
        [Route("api/estadosReservas")]
        public IActionResult Get()
        {
            IEnumerable<estados_reservas> estadosList = from e in _contexto.estados_reserva select e;
            if (estadosList.Count() > 0)
            {
                return Ok(estadosList);
            }
            return NotFound();
        }
    }
}
