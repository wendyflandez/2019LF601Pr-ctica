using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2019LF601Práctica.Models;

namespace _2019LF601Práctica
{
    public class _2019LF601Context:DbContext
    {
        public _2019LF601Context(DbContextOptions<_2019LF601Context> options) : base(options)
        {
        }

        public DbSet<equipos> equipos { get; set; }
        public DbSet<estados_equipo> Estados_equipo { get; set; }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<tipoEquipo> tipo_equipo { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<carreras> carreras { get; set; }
        public DbSet<facultades> facultades { get; set; }
        public DbSet<estados_reservas> estados_reserva { get; set; }
    }
}

