using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tarea6Empresa.DAL;
using Tarea6Empresa.Entidades;

namespace Tarea6Empresa.Bll
{
    public  class DepartamentoBLL
    {
        public static List<Departamento> GetList(Expression<Func<Departamento, bool>> expression)
        {
            List<Departamento> Departamento = new List<Departamento>();
            Contexto db = new Contexto();
            try
            {
                Departamento = db.Departamento.Where(expression).ToList();
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Departamento;
        }
    }
}
