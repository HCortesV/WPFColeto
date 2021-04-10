using ElColeto.Domain.Entities;
using ElColeto.Persistence.Sqlite;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElColeto.Persistence
{
    public class ColectivoContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new CustomInitialize(modelBuilder);
            
            var functionType = System.Data.SQLite.FunctionType.Aggregate;
            var instance = System.Data.SQLite.EF6.SQLiteProviderFactory.Instance;

            modelBuilder.Entity<Vehiculo>()
                .HasKey(k=>k.VehiculoId)
               .HasOptional(s => s.Tarjeta)
               .WithRequired(v => v.Vehiculo);

            modelBuilder.Entity<Tarjeta>()
                .HasKey(k => k.VehiculoId);

            modelBuilder.Entity<RegistroTarjeta>()
                        .HasRequired(a => a.Tarjeta)
                        .WithMany(b => b.RegistroTarjeta)
                        .HasForeignKey(b => b.VehiculoId);

            Database.SetInitializer(sqliteConnectionInitializer);
        }


        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Chofer> Choferes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<RegistroTarjeta> RegistrosTarjeta { get; set; }
    }
}
