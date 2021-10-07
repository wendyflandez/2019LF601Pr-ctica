using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2019LF601Práctica.Models
{
    public class facultades
    {
        [Key]
        public int facultad_id { get; set; }
        public string nombre_facultad { get; set; }
    }
}
