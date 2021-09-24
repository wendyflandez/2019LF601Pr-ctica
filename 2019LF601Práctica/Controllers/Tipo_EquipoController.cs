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
    public class Tipo_EquipoController : ControllerBase
    {
        private readonly _2019LF601Context _contexto;
        public Tipo_EquipoController(_2019LF601Context miContexto)
        {
            this._contexto = miContexto;

        }
        [HttpGet]
        [Route("api/TipoEquipo")]
        public IActionResult Get()
        {

            IEnumerable<tipoEquipo> TequipoList = from e in _contexto.tipo_equipo select e;
            if (TequipoList.Count() > 0)
            {
                return Ok(TequipoList);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/TipoEquipo/{id}")]
        public IActionResult getbyId(int id)
        {
            tipoEquipo eq1 = (from e in _contexto.tipo_equipo
                                  where e.id_tipo_equipo == id
                                  select e).FirstOrDefault();
            if (eq1 != null)
            {
                return Ok(eq1);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/Tipoequipo")]
        public IActionResult GuardarTipo([FromBody]tipoEquipo guardar)
        {
            _contexto.tipo_equipo.Add(guardar);
            _contexto.SaveChanges();
            return Ok(guardar);
        }
        [HttpPut]
        [Route("api/TipoEquipo")]
        public IActionResult upDateEquipos([FromBody] tipoEquipo modificar)
        {
            tipoEquipo existeEquipo = (from e in _contexto.tipo_equipo
                                    where e.id_tipo_equipo == modificar.id_tipo_equipo
                                    select e).FirstOrDefault();
            if (existeEquipo is null)
            {
                return NotFound();
            }
            existeEquipo.descripcion = modificar.descripcion;
            existeEquipo.estado = modificar.estado;
            _contexto.Entry(existeEquipo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
            return Ok(existeEquipo);
        }
    }
}
