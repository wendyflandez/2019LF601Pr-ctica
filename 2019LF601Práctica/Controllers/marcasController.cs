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
    public class marcasController : ControllerBase
    {
        private readonly _2019LF601Context _contexto;
        public marcasController(_2019LF601Context miContexto)
        {
            this._contexto = miContexto;

        }
        [HttpGet]
        [Route("api/marcas")]
        public IActionResult Get()
        {

            IEnumerable<marcas> marcasList = from e in _contexto.marcas select e;
            if (marcasList.Count() > 0)
            {
                return Ok(marcasList);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/marcas/{id}")]
        public IActionResult getbyId(int id)
        {
            marcas eq1 = (from e in _contexto.marcas
                                  where e.id_marcas == id
                                  select e).FirstOrDefault();
            if (eq1 != null)
            {
                return Ok(eq1);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/marcas")]
        public IActionResult GuardarTipo([FromBody] marcas guardar)
        {
            _contexto.marcas.Add(guardar);
            _contexto.SaveChanges();
            return Ok(guardar);
        }
        [HttpPut]
        [Route("api/marcas")]
        public IActionResult upDateEquipos([FromBody] marcas modificar)
        {
            marcas existeEquipo = (from e in _contexto.marcas
                                    where e.id_marcas == modificar.id_marcas
                                    select e).FirstOrDefault();
            if (existeEquipo is null)
            {
                return NotFound();
            }
            existeEquipo.nombre_marca = modificar.nombre_marca;
            existeEquipo.estados = modificar.estados;
            _contexto.Entry(existeEquipo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
            return Ok(existeEquipo);
        }
    }
}
