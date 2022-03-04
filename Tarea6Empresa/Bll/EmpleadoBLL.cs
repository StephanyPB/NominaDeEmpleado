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
    public class EmpleadoBLL
    {
        public static bool Guardar(Empleado Empleado)
        {
            if (!Existe(Empleado.Id))
                return Insertar(Empleado);
            else
                return Modificar(Empleado);
        }
        private static bool Insertar(Empleado Empleado)
        {
            bool paso = false;
            //Creamos una instancia del contexto para poder conectar con la DB
            Contexto db = new Contexto();
            try
            {
                db.Empleado.Add(Empleado);
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { 
                throw;
            }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Modificar una entidad en la base de datos
        /// </summary>
        private static bool Modificar(Empleado Empleado)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(Empleado).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Eliminar una entidad en la base de datos
        /// </summary>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                Empleado Empleado = db.Empleado.Find(id);

                if (Existe(id))
                {
                    db.Empleado.Remove(Empleado);
                    paso = db.SaveChanges() > 0;
                }

            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Buscar una entidad en la base de datos
        /// </summary>
        public static Empleado Buscar(int id)
        {
            Contexto db = new Contexto();
            Empleado Empleado = new Empleado();
            try
            {
                Empleado = db.Empleado.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Empleado;
        }
        /// <summary>
        /// Permite extraer una lista de Usuario de la base de datos
        /// </summary>
        public static List<Empleado> GetList(Expression<Func<Empleado, bool>> expression)
        {
            List<Empleado> Empleado = new List<Empleado>();
            Contexto db = new Contexto();
            try
            {
                Empleado = db.Empleado.Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Empleado;
        }
        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();
            try
            {
                encontrado = db.Empleado.Any(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
    }
}
