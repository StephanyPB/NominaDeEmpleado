using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea6Empresa.Entidades
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }  
        public string Descripcion { get; set;}

    }
}
