﻿using Microsoft.EntityFrameworkCore;
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
    public class VentaBLL
    {
        public static bool Guardar(Ventas ventas)
        {
            if (!Existe(ventas.VentaId))//si no existe insertamos
                return Insertar(ventas);
            else
                return Modificar(ventas);
        }
        private static bool Insertar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Ventas.Add(ventas);

                 foreach (var detalle in ventas.Detalle)
                 {
                     contexto.Entry(detalle.Articulo).State = EntityState.Modified;
                     contexto.Entry(detalle.Empleado).State = EntityState.Modified;

                    
                     //detalle.TiempoTotal = cliente.Detalle.Sum(e => e.Tiempo);



                 }
                if (contexto.Ventas.Add(ventas) != null)
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
        private static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var VentaAnterior = contexto.Ventas
                     .Where(x => x.VentaId == ventas.VentaId)
                     .Include(x => x.Detalle)
                     .ThenInclude(x => x.Articulo)
                     .Include(x => x.Detalle)
                     .ThenInclude(x => x.Empleado)
                     .AsNoTracking() 
                     .SingleOrDefault();

                 //busca la entidad en la base de datos y la elimina
                 foreach (var detalle in VentaAnterior.Detalle)
                 {
                    // detalle.Empleado
                 }
                
                contexto.Database.ExecuteSqlRaw($"Delete FROM DetalleTarea Where VentaId={ventas.VentaId}");

                foreach (var item in ventas.Detalle)
                {

                    contexto.Entry(item).State = EntityState.Added;
                }
               
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(ventas).State = EntityState.Modified;
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
                var ventas = contexto.Ventas.Find(id);

                if (ventas != null)
                {
                    //busca la entidad en la base de datos y la elimina
                     foreach (var detalle in ventas.Detalle)
                     {
                         detalle.Empleado.EmpleadoId -= 1;
                        detalle.Articulo.ArticuloId -= 1;

                         //detalle.Persona.CantidadGrupos -= 1;
                     }

                    contexto.Ventas.Remove(ventas); //remover la entidad
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
        public static Ventas Buscar(int id)
        {
            Ventas ventas;
            Contexto contexto = new Contexto();

            try
            {
               // ventas = contexto.Ventas.Find(id);
                ventas = contexto.Ventas.Include(x => x.Detalle)
                    .Where(x => x.VentaId == id)
                     .Include(x => x.Detalle)
                    .ThenInclude(x => x.Articulo)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.Empleado)
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
            return ventas;
        }
        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> criterio)
        {
            List<Ventas> Lista = new List<Ventas>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Ventas.Where(criterio).ToList();
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
                encontrado = contexto.Ventas.Any(e => e.VentaId == id);
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