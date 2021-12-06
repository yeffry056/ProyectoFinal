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
    public class CompraBLL
    {
        public static bool Guardar(Compras compra)
        {
            if (!Existe(compra.CompraId))//si no existe insertamos
                return Insertar(compra);
            else
                return Modificar(compra);
        }
        
        private static bool Insertar(Compras compra)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Compras.Add(compra);

                foreach (var detalle in compra.CompraDetalles)
                {
                    compra.Total += detalle.Costo;
                   

                }
              

                if (contexto.Compras.Add(compra) != null)
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

        private static bool Modificar(Compras compra)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var VentaAnterior = contexto.Compras
                    .Where(x => x.CompraId == compra.CompraId)
                    .Include(x => x.CompraDetalles)
                    .AsNoTracking()
                    .SingleOrDefault();

                // foreach (var item in ventas.Detalle)
                // {



                //busca la entidad en la base de datos y la elimina
                foreach (var detalle in VentaAnterior.CompraDetalles)
                {
                  
                    detalle.CompraId -= 1;
                    compra.Total -= detalle.Costo;

                }
                contexto.Database.ExecuteSqlRaw($"Delete FROM CompraDetalle Where CompraId={compra.CompraId}");

                foreach (var item in compra.CompraDetalles)
                {


                    compra.Total += item.Costo;
                    contexto.Entry(item).State = EntityState.Added;




                }
                contexto.Entry(compra).State = EntityState.Modified;
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
                var compra = contexto.Compras.Find(id);

                if (compra != null)
                {
                    contexto.Compras.Remove(compra); //remover la entidad
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

        public static Compras Buscar(int id)
        {
            Compras compra;
            Contexto contexto = new Contexto();

            try
            {
               
                //compra = contexto.Compras.Find(id);
                compra = contexto.Compras.Include(x => x.CompraDetalles)
                    .Where(p => p.CompraId == id)
                    .Include(x => x.CompraDetalles)
                    .SingleOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return compra;
        }

        public static List<Compras> GetList(Expression<Func<Compras, bool>> criterio)
        {
            List<Compras> Lista = new List<Compras>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Compras.Where(criterio).ToList();
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
                encontrado = contexto.Compras.Any(e => e.CompraId == id);
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
