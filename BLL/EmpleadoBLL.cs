using Microsoft.EntityFrameworkCore;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL
{
    public class EmpleadoBLL
    {
        public static bool Guardar(Empleados empleado)
        {
            if (!Existe(empleado.EmpleadoId))//si no existe insertamos
                return Insertar(empleado);
            else
                return Modificar(empleado);
        }

        private static bool Insertar(Empleados empleado)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Empleados.Add(empleado) != null)
                    paso = contexto.SaveChanges() > 0;
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
        }//Listo

        private static bool Modificar(Empleados empleado)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(empleado).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
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
        }//Listo

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var empleados = contexto.Empleados.Find(id);

                if (empleados != null)
                {
                    contexto.Empleados.Remove(empleados); //remover la entidad
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
        }//Listo

        public static Empleados Buscar(int id)
        {
            Empleados empleado;
            Contexto contexto = new Contexto();

            try
            {
                empleado = contexto.Empleados.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return empleado;
        }//Listo

        public static List<Empleados> GetList(Expression<Func<Empleados, bool>> criterio)
        {
            List<Empleados> Lista = new List<Empleados>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Empleados.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }//Listo

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Empleados.Any(e => e.EmpleadoId == id);
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
        }//Listo
    }
}
