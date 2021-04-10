using System;
using System.Collections.Generic;
using System.Text;

namespace ElColeto.Application.DTO
{
    public class TarjetaDto
    {
        public int Id { get; set; }
        public string Tarjeta { get; set; }
        public string Patente { get; set; }
        public string NumeroVehiculo { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    }
}
