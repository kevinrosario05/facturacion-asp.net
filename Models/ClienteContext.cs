using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    public class ClienteContext:DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Vendidos> Vendidos { get; set; }
        public DbSet<Reportes> Reportes { get; set; }

        public ClienteContext(): base() 
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           // => options.UseSqlServer("Server=DESKTOP-UFEMCOT\\SQLEXPRESS;Database=FacturacionApp;Trusted_Connection=True;MultipleActiveResultSets=true");
         => options.UseSqlServer("Server=tcp:proyectofinalp3.database.windows.net,1433;Initial Catalog=appFacturacion;Persist Security Info=False;User ID=proyecto;Password=24022903Jhonni;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }

}

