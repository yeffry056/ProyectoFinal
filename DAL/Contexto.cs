using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Fabricantes> Fabricantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\TalleresNelson.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 1,
                Fecha = DateTime.Now,
                Descripcion = "Administrador"
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 2,
                Fecha = DateTime.Now,
                Descripcion = "Usuario"
            });

            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombre = "Jefferson",
                RolId = 1,
                
                NombreUsuario = "user01",
                Fecha = DateTime.Now,
                Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4"//clave: 1234
            }) ;
        }
    }
}
