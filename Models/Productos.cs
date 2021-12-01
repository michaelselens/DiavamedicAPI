using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diavamedic.Models
{
    public class Productos
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int codigo { get; set; }
        public string lote { get; set; }
        public int aniovencimiento { get; set; }
    }
}
