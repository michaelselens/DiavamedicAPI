using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diavamedic.Models
{
    public class Remitos
    {
        [Key]
        public int id { get; set; }
        public int nroremito { get; set; }
        public int linea { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public int idvehiculo { get; set; }
    }
}
