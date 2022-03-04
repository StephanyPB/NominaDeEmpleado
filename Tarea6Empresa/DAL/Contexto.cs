using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea6Empresa.Entidades;

namespace Tarea6Empresa.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Nomina> Nomina { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source = data\empleadocontrol.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { DepartamentoId = 1, Descripcion = "Financiero" },
                new Departamento { DepartamentoId = 2, Descripcion = "Recursos Humanos" },
                new Departamento { DepartamentoId = 3, Descripcion = "Compras" },
                new Departamento { DepartamentoId = 4, Descripcion = "Administrador" });

            modelBuilder.Entity<Roles>().HasData(
                new Roles { RolId = 1, Descripcion = "Gerente" },
                new Roles { RolId = 2, Descripcion = "Secreatrio" },
                new Roles { RolId = 3, Descripcion = "Contable" },
                new Roles { RolId = 4, Descripcion = "Desarrollador" },
                new Roles { RolId = 5, Descripcion = "Desarrollador" });
        }

       
    }

}
