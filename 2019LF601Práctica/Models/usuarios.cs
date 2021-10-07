using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2019LF601Práctica.Models
{
    public class usuarios
    {
        [Key]
        public int usuario_id { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public string tipo { get; set; }
        public string carnet { get; set; }
        public int carrera_id { get; set; }
    }
}
