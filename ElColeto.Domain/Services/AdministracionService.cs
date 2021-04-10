using ElColeto.Domain.Contracts;
using ElColeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElColeto.Domain.Services
{
    public class AdministracionService
    {
        private IUnitOfWork _uow;
        public AdministracionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> CrearTarjeta(string numero,string patente)
        {
            var vehiculo = await _uow.Repositorio<Vehiculo>().GetAsync(w => w.Patente == patente);

            var tarjeta = new Tarjeta()
            {
                Numero = numero,
                Activo = true,
                FechaRegistro = DateTime.Now,
                VehiculoId = vehiculo.VehiculoId
            };

            await _uow.Repositorio<Tarjeta>().CreateAsync(tarjeta);

            return await _uow.CommitAsync() > 0;
        }

        public async Task<Tarjeta> ObtenerTarjeta(string numero)
        {
            return await _uow.Repositorio<Tarjeta>().GetFirstOrDefaultAsync(w => w.Numero == numero);
        }

        public async Task<bool> CrearVehiculo(string patente,int numero)
        {
            var vehiculo = new Vehiculo()
            { 
                Patente = patente,
                Numero = numero
            };

            await _uow.Repositorio<Vehiculo>().CreateAsync(vehiculo);

            return await _uow.CommitAsync() > 0;
        }

        public async Task<bool> AsignarVehiculoTarjeta(string numero,string patente)
        {
            var vehiculo = await _uow.Repositorio<Vehiculo>().GetAsync(w => w.Patente == patente);
            var tarjeta = await _uow.Repositorio<Tarjeta>().GetAsync(w => w.Numero == numero);

            tarjeta.Vehiculo = vehiculo;

            return await _uow.CommitAsync() > 0;
        }

        public async Task<IEnumerable<Vehiculo>> ObtenerVehiculos()
        {
            return await _uow.Repositorio<Vehiculo>().GetAllAsync(w => true);
        }
 
    }
}
