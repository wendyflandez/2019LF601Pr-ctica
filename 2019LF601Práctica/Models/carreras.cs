﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2019LF601Práctica.Models
{
    public class carreras
    {
        [Key]
        public int carrera_id { get; set; }
        public string nombre_carrera { get; set; }
        public string facultad_id { get; set; }
    }
}
