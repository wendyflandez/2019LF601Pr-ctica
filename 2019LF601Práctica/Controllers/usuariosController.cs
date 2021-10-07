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
    public class usuariosController : ControllerBase
    {
        private readonly _2019LF601Context _contexto;
        public usuariosController(_2019LF601Context miContexto)
        {
            this._contexto = miContexto;

        }
        [HttpGet]
        [Route("api/usuarios")]
        public IActionResult Get()
        {
            IEnumerable<usuarios> usuarioList = from e in _contexto.usuarios select e;
            if (usuarioList.Count() > 0)
            {
                return Ok(usuarioList);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/usuarios/userjoin")]
        public IActionResult Join()
        {
            var usuarioList = from e in _contexto.usuarios 
                              join c in _contexto.carreras on e.carrera_id equals c.carrera_id
                              select new{
                                  e.usuario_id,
                                  e.nombre,
                                  e.documento,
                                  e.tipo,
                                  e.carnet,
                                  e.carrera_id,
                                  c.nombre_carrera,
                                  c.facultad_id                              
            };
            if (usuarioList.Count() > 0)
            {
                return Ok(usuarioList);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/usuarios/{id}")]
        public IActionResult GetbyId(int id)
        {
            var unUsuario = from e in _contexto.usuarios
                            join c in _contexto.carreras on e.carrera_id equals c.carrera_id
                            where e.usuario_id == id
                              select new
                              {
                                  e.usuario_id,
                                  e.nombre,
                                  e.documento,
                                  e.tipo,
                                  e.carnet,
                                  e.carrera_id,
                                  c.nombre_carrera,
                                  c.facultad_id
                              };
            if (unUsuario.Count() > 0)
            {
                return Ok(unUsuario);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("api/usuarios/")]
        public IActionResult GetbyNombre(string nombre)
        {
            var unUsuario = from e in _contexto.usuarios
                            join c in _contexto.carreras on e.carrera_id equals c.carrera_id
                            where e.nombre.Contains(nombre)
                            select new
                            {
                                e.usuario_id,
                                e.nombre,
                                e.documento,
                                e.tipo,
                                e.carnet,
                                e.carrera_id,
                                c.nombre_carrera,
                                c.facultad_id
                            };
            if (unUsuario.Count() > 0)
            {
                return Ok(unUsuario);
            }
            return NotFound();
        }
    }
}
