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
    public class VehiculoBLL
    {
        public static bool Guardar(Vehiculos vehiculo)
        {
            if (!Existe(vehiculo.VehiculoId))//si no existe insertamos
                return Insertar(vehiculo);
            else
                return Modificar(vehiculo);
        }
        private static bool Insertar(Vehiculos vehiculo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Vehiculos.Add(vehiculo) != null)
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
        }
        private static bool Modificar(Vehiculos vehiculo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(vehiculo).State = EntityState.Modified;
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
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var vehiculo = contexto.Vehiculos.Find(id);

                if (vehiculo != null)
                {
                    contexto.Vehiculos.Remove(vehiculo); //remover la entidad
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
        public static Vehiculos Buscar(int id)
        {
            Vehiculos vehiculo;
            Contexto contexto = new Contexto();

            try
            {
                vehiculo = contexto.Vehiculos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return vehiculo;
        }
        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> criterio)
        {
            List<Vehiculos> Lista = new List<Vehiculos>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Vehiculos.Where(criterio).ToList();
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
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Vehiculos.Any(e => e.VehiculoId == id);
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
    }
}
