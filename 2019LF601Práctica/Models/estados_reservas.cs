using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2019LF601Práctica.Models
{
    public class estados_reservas
    {
        [Key]
        public int estado_res_id { get; set; }
        public string estado { get; set; }
    }
}
