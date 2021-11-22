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
    public class FabricanteBLL
    {
        public static bool Guardar(Fabricantes fabricante)
        {
            if (!Existe(fabricante.FabricanteId))//si no existe insertamos
                return Insertar(fabricante);
            else
                return Modificar(fabricante);
        }
        private static bool Insertar(Fabricantes fabricante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                
                if (contexto.Fabricantes.Add(fabricante) != null)
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
        private static bool Modificar(Fabricantes fabricante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
               
                contexto.Entry(fabricante).State = EntityState.Modified;
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
                var fabricante = contexto.Fabricantes.Find(id);

                if (fabricante != null)
                {
                  

                    contexto.Fabricantes.Remove(fabricante); //remover la entidad
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
        public static Fabricantes Buscar(int id)
        {
            Fabricantes fabricante;
            Contexto contexto = new Contexto();

            try
            {
                fabricante = contexto.Fabricantes.Find(id);
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return fabricante;
        }
        public static List<Fabricantes> GetFabricantes()
        {
            List<Fabricantes> Lista = new List<Fabricantes>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Fabricantes.ToList();
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
        public static List<Fabricantes> GetListido()
        {
            List<Fabricantes> Lista = new List<Fabricantes>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Fabricantes.ToList();
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
        public static List<Fabricantes> GetList(Expression<Func<Fabricantes, bool>> criterio)
        {
            List<Fabricantes> Lista = new List<Fabricantes>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Fabricantes.Where(criterio).ToList();
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
                encontrado = contexto.Fabricantes.Any(e => e.FabricanteId == id);
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
