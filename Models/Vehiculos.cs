using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diavamedic.Models
{
    public class Vehiculos
    {
        [Key]
        public int id { get; set; }
        public string marca { get; set; }
        public string patente { get; set; }
        public int kmrecorridos { get; set; }
        public int idconductor { get; set; }
    }
}
