using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElColeto.Domain.Entities
{
    public class RegistroTarjeta
    {
        public int RegistroTarjetaId { get; set; }
        public DateTime FechaRegistro { get; set; }

        public int VehiculoId { get; set; }
        public Tarjeta Tarjeta { get; set; }
    }
}
