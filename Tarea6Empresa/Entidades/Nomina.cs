using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea6Empresa.Entidades
{
    public class Nomina
    {
        [Key]
        public int NominaId { get; set; }
        public int EmpleadoId { get; set; }
        public double SalarioMensual { get; set; }
        public double HorasExtra { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double SFS { get; set; }
        public double AFP { get; set; }
        public double ISR { get; set; }
        public double SueldoTotal { get; set; }
        public double TotalDecuentos { get; set; }

        //[ForeignKey("NominaId")]

    }
}
