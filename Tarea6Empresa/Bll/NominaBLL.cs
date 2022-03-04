using Microsoft.EntityFrameworkCore;
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
    public class NominaBLL
    {
      
        public static bool Guardar(Nomina Nomina)
        {
            if (!Existe(Nomina.NominaId))
                return Insertar(Nomina);
            else
                return Modificar(Nomina);
        }

        private static bool Insertar(Nomina Nomina)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Nomina.Add(Nomina);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }
     
        public static bool Modificar(Nomina Nomina)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(Nomina).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }
       
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var nominas = contexto.Nomina.Find(id);
                if (nominas != null)
                {
                    contexto.Nomina.Remove(nominas);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
      
        public static Nomina Buscar(int id)
        {
            Contexto db = new Contexto();
            Nomina nominas;

            try
            {
                nominas = db.Nomina.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return nominas;
        }
        
        public static List<Nomina> GetList(Expression<Func<Nomina, bool>> criterio)
        {
            List<Nomina> lista = new List<Nomina>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Nomina.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Nomina.Any(c => c.NominaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        
        public static List<Nomina> GetList()
        {
            List<Nomina> nominas = new List<Nomina>();
            Contexto contexto = new Contexto();

            try
            {
                nominas = contexto.Nomina.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return nominas;
        }

        public static List<Nomina> GetNominas()
        {
            List<Nomina> lista = new List<Nomina>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Nomina.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
