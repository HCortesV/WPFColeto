using ElColeto.Domain.Contracts;
using ElColeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElColeto.Domain.Services
{
    public class RegistroService
    {
        private IUnitOfWork _uow;
        public RegistroService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> AgregarRegistro(string numero)
        {
            var tarjeta = await _uow.Repositorio<Tarjeta>().GetAsync(w => w.Numero == numero);

            await _uow.Repositorio<RegistroTarjeta>().CreateAsync(new RegistroTarjeta()
            {
                VehiculoId = tarjeta.VehiculoId,
                FechaRegistro = DateTime.Now,
            });
            return await _uow.CommitAsync() > 0;
        }

        public async Task<IEnumerable<RegistroTarjeta>> ObtenerRegistros(int size = 0)
        {
            return await _uow.Repositorio<RegistroTarjeta>().GetAllAsync(w => true, o => o.OrderByDescending(d => d.FechaRegistro), size, true,i=>i.Tarjeta);
        }
        public async Task<IEnumerable<Tarjeta>> ObtenerRegistros(string numero)
        {
            return await _uow.Repositorio<Tarjeta>().GetAllAsync(w => w.Numero == numero);
        }
    }
}
