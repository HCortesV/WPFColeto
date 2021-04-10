using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElColeto.Domain.Entities
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Patente { get; set; }
        public int Numero { get; set; }
        public string UrlFoto { get; set; }
        public ICollection<Chofer> Choferes { get; set; }
        public virtual Tarjeta Tarjeta { get; set; }
    }
}
