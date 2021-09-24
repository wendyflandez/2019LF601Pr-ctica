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
    public class equiposController : ControllerBase
    {
        private readonly _2019LF601Context _contexto;
        public equiposController(_2019LF601Context miContexto)
        {
            this._contexto = miContexto;

        }
        [HttpGet]
        [Route("api/equipos")]
        public IActionResult Get()
        {
            IEnumerable<equipos> equipoList = from e in _contexto.equipos select e;
            if (equipoList.Count() > 0)
            {
                return Ok(equipoList);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/equipos/{id}")]
        public IActionResult getbyId(int id)
        {
            equipos eq1 = (from e in _contexto.equipos
                           where e.id_equipos == id
                           select e).FirstOrDefault();
            if (eq1 != null)
            {
                return Ok(eq1);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/equipos/buscarNombre/{nombre}")]
        public IActionResult getbyNombre(string nombre)
        {
            IEnumerable<equipos> nombreEquipo = from e in _contexto.equipos
                                                where e.nombre.Contains(nombre)
                                                select e;
            if (nombreEquipo.Count()>0)
            {
                return Ok(nombreEquipo);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/equipos")]
        public IActionResult GuardarTipo([FromBody] equipos guardar)
        {
            try
            {
                IEnumerable<equipos> equipoExiste = from e in _contexto.equipos
                                                    where e.nombre == guardar.nombre
                                                    select e;
                if (equipoExiste.Count()>0)
                {
                    _contexto.equipos.Add(guardar);
                    _contexto.SaveChanges();
                    return Ok(guardar); 
                }
                return BadRequest();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut]
        [Route("api/equipos")]
        public IActionResult upDateEquipos([FromBody] equipos modificar)
        {
            equipos existeEquipo = (from e in _contexto.equipos
                                                where e.id_equipos == modificar.id_equipos
                                                select e).FirstOrDefault();
            if (existeEquipo is null)
            {
                return NotFound();
            }
            existeEquipo.nombre = modificar.nombre;
            existeEquipo.descripcion = modificar.descripcion;
            existeEquipo.modelo = modificar.modelo;
            _contexto.Entry(existeEquipo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
            return Ok(existeEquipo);
        }

    }
}
