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
    public class carrerasController : ControllerBase
    {
        private readonly _2019LF601Context _contexto;
        public carrerasController(_2019LF601Context miContexto)
        {
            this._contexto = miContexto;

        }
        [HttpGet]
        [Route("api/carreras")]
        public IActionResult Get()
        {
            IEnumerable<carreras> carreraList = from e in _contexto.carreras select e;
            if (carreraList.Count() > 0)
            {
                return Ok(carreraList);
            }
            return NotFound();
        }
    }
}
