using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElColeto.Domain.Entities
{
    public class Tarjeta
    {
        [ForeignKey("Vehiculo")]
        public int VehiculoId { get; set; }
        public string Numero { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        public ICollection<RegistroTarjeta> RegistroTarjeta { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
