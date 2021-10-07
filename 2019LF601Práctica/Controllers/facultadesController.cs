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
    public class facultadesController : ControllerBase
    {
        private readonly _2019LF601Context _contexto;
        public facultadesController(_2019LF601Context miContexto)
        {
            this._contexto = miContexto;

        }
        [HttpGet]
        [Route("api/facultad")]
        public IActionResult Get()
        {
            IEnumerable<facultades> facultadList = from e in _contexto.facultades select e;
            if (facultadList.Count() > 0)
            {
                return Ok(facultadList);
            }
            return NotFound();
        }
    }
}
