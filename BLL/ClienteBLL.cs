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
    public class ClienteBLL
    {
        public static bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))//si no existe insertamos
                return Insertar(cliente);
            else
                return Modificar(cliente);
        }
        private static bool Insertar(Clientes cliente)
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
                if (contexto.Clientes.Add(cliente) != null)
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
        private static bool Modificar(Clientes cliente)
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
                contexto.Entry(cliente).State = EntityState.Modified;
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
                var cliente = contexto.Clientes.Find(id);

                if (cliente != null)
                {
                    //busca la entidad en la base de datos y la elimina
                   /* foreach (var detalle in tarea.Detalle)
                    {
                        detalle.TipoTareaa.TipoId -= 1;

                        //detalle.Persona.CantidadGrupos -= 1;
                    }*/

                    contexto.Clientes.Remove(cliente); //remover la entidad
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
        public static Clientes Buscar(int id)
        {
            Clientes cliente;
            Contexto contexto = new Contexto();

            try
            {
                cliente = contexto.Clientes.Find(id);
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
            return cliente;
        }
        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> Lista = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Clientes.Where(criterio).ToList();
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
                encontrado = contexto.Clientes.Any(e => e.ClienteId == id);
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
