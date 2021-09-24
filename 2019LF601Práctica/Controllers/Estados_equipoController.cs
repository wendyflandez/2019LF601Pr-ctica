using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2019LF601Práctica.Models;
using Microsoft.EntityFrameworkCore;

namespace _2019LF601Práctica.Controllers
{
    [ApiController]
    public class Estados_equipoController : ControllerBase
    {
        private readonly _2019LF601Context _contexto;
        public Estados_equipoController(_2019LF601Context miContexto)
        {
            this._contexto = miContexto;

        }
        [HttpGet]
        [Route("api/EstadoEquipo")]
        public IActionResult Get()
        {

            IEnumerable<estados_equipo> EsequipoList = from e in _contexto.Estados_equipo select e;
            if (EsequipoList.Count() > 0)
            {
                return Ok(EsequipoList);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/EstadoEquipo/{id}")]
        public IActionResult getbyId(int id)
        {
            estados_equipo eq1 = (from e in _contexto.Estados_equipo
                           where e.id_estados_equipo == id
                           select e).FirstOrDefault();
            if (eq1 != null)
            {
                return Ok(eq1);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/EstadoEquipo")]
        public IActionResult GuardarTipo([FromBody] estados_equipo guardar)
        {
            _contexto.Estados_equipo.Add(guardar);
            _contexto.SaveChanges();
            return Ok(guardar);
        }
        [HttpPut]
        [Route("api/EstadoEquipo")]
        public IActionResult upDateEquipos([FromBody] estados_equipo modificar)
        {
            estados_equipo existeEquipo = (from e in _contexto.Estados_equipo
                                    where e.id_estados_equipo == modificar.id_estados_equipo
                                    select e).FirstOrDefault();
            if (existeEquipo is null)
            {
                return NotFound();
            }
            existeEquipo.estado = modificar.estado;
            existeEquipo.descripcion = modificar.descripcion;
            _contexto.Entry(existeEquipo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
            return Ok(existeEquipo);
        }
    }
}
