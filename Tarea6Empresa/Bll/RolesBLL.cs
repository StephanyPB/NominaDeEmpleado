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
    public class RolesBLL
    {
        public static List<Roles> GetList(Expression<Func<Roles, bool>> expression)
        {
            List<Roles> Roles = new List<Roles>();
            Contexto db = new Contexto();
            try
            {
                Roles = db.Roles.Where(expression).ToList();
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
            return Roles;
        }
    }
}
