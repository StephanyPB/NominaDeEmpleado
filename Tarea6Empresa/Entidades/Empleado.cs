using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea6Empresa.Entidades
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public double Salario { get; set; }
        public DateTime fechaIngreso { get; set; } = DateTime.Now;
        public string Edad { get; set; }
        /*
        [ForeignKey("Id")]
        public virtual Empleado empleado { get; set; }

        [ForeignKey("RolId")]  
        public virtual Roles roles { get; set; }

        [ForeignKey("DepartamentoId")]
        public virtual Departamento Departamento { get; set; }

        */
        public Empleado(int id, string nombre, string telefono, double salario, DateTime fechaIngreso, string edad)
        {
            Id = id;
            Nombres = nombre;
           
            Telefono = telefono;
            Salario = salario;
            this.fechaIngreso = fechaIngreso;
            edad = Edad;
        }
        public Empleado()
        {
            Id = 0;
            Nombres = string.Empty;
            
            Telefono = string.Empty;
            Salario = 0;
            Edad = string.Empty;
        }
    }
}
