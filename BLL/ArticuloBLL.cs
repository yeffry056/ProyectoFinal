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
    public class ArticuloBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            if (!Existe(articulos.ArticuloId))//si no existe insertamos
                return Insertar(articulos);
            else
                return Modificar(articulos);
        }
        private static bool Insertar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                //contexto.Clientes.Add(cliente);

                /* foreach (var detalle in cliente.Detalle)
                 {
                     contexto.Entry(detalle.TipoTareaa).State = EntityState.Modified;
                     // contexto.Entry(detalle.TiempoTotal).State = EntityState.Modified;
                     detalle.TiempoTotal = cliente.Detalle.Sum(e => e.Tiempo);



                 }*/
                if (contexto.Articulos.Add(articulos) != null)
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
        private static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                /* var grupoAnterior = contexto.Tarea
                     .Where(x => x.TareaId == tarea.TareaId)
                     .Include(x => x.Detalle)
                     .ThenInclude(x => x.TipoTareaa)
                     .AsNoTracking() 
                     .SingleOrDefault();

                 //busca la entidad en la base de datos y la elimina
                 foreach (var detalle in tareaAnterior.Detalle)
                 {
                     detalle.TipoTareaa -= 1;
                 }*/
                //List<DetalleTarea> detalle = Buscar(tarea.TareaId).Detalle;
                /*contexto.Database.ExecuteSqlRaw($"Delete FROM DetalleTarea Where TareaId={tarea.TareaId}");

                foreach (var item in tarea.Detalle)
                {

                    contexto.Entry(item).State = EntityState.Added;
                }*/
                // List<DetalleTarea> nuevo = tarea.Detalle;
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(articulos).State = EntityState.Modified;
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
                var articulos = contexto.Articulos.Find(id);

                if (articulos != null)
                {
                    //busca la entidad en la base de datos y la elimina
                    /* foreach (var detalle in tarea.Detalle)
                     {
                         detalle.TipoTareaa.TipoId -= 1;

                         //detalle.Persona.CantidadGrupos -= 1;
                     }*/

                    contexto.Articulos.Remove(articulos); //remover la entidad
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
        public static Articulos Buscar(int id)
        {
            Articulos articulos;
            Contexto contexto = new Contexto();

            try
            {
                articulos = contexto.Articulos.Find(id);
                /*tarea = contexto.Tarea.Include(x => x.Detalle)
                    .Where(x => x.TareaId == id)
                     .Include(x => x.Detalle)
                    .ThenInclude(x => x.TipoTareaa)
                    .SingleOrDefault();*/
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return articulos;
        }
        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> criterio)
        {
            List<Articulos> Lista = new List<Articulos>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Articulos.Where(criterio).ToList();
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
        public static List<Articulos> GetListado()
        {
            List<Articulos> Lista = new List<Articulos>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Articulos.ToList();
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
                encontrado = contexto.Articulos.Any(e => e.ArticuloId == id);
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
