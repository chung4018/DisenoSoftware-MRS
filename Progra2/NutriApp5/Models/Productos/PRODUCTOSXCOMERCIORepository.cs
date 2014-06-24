using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class PRODUCTOSXCOMERCIORepository : IPRODUCTOSXCOMERCIORepository
    {
        Entities context = new Entities();

        public IQueryable<PRODUCTOSXCOMERCIO> All
        {
            get { return context.PRODUCTOSXCOMERCIO; }
        }

        public IQueryable<PRODUCTOSXCOMERCIO> AllIncluding(params Expression<Func<PRODUCTOSXCOMERCIO, object>>[] includeProperties)
        {
            IQueryable<PRODUCTOSXCOMERCIO> query = context.PRODUCTOSXCOMERCIO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PRODUCTOSXCOMERCIO Find(int id)
        {
            return context.PRODUCTOSXCOMERCIO.Find(id);
        }

        public void InsertOrUpdate(PRODUCTOSXCOMERCIO productosxcomercio)
        {
            if (productosxcomercio.ID == default(int)) {
                // New entity
                productosxcomercio.ID = getLastNumber()+1;
                context.PRODUCTOSXCOMERCIO.Add(productosxcomercio);
                context.SaveChanges();
            } else {
                // Existing entity
                context.Entry(productosxcomercio).State = EntityState.Modified;
            }
        }

        public void DeleteAllProductosComercio(int idComercio)
        {
            IQueryable<PRODUCTOSXCOMERCIO> productos = (from PRODUCTOSXCOMERCIO p in context.PRODUCTOSXCOMERCIO
                                                        where p.ID_COMERCIO == idComercio
                                                         select p);
            foreach (var producto in productos)
            {
                this.Delete(producto.ID);
            }
            this.Save();
        }
        public void DeleteAllComercioProductos(int idProducto)
        {
            IQueryable<PRODUCTOSXCOMERCIO> productos = (from PRODUCTOSXCOMERCIO p in context.PRODUCTOSXCOMERCIO
                                                        where p.ID_PRODUCTO == idProducto
                                                        select p);
            foreach (var producto in productos)
            {
                this.Delete(producto.ID);
            }
            this.Save();
        }

        //recupera el ultimo registro de la base de datos  para los usuarios
        private int getLastNumber()
        {
            int resp = 0;
            IQueryable<PRODUCTOSXCOMERCIO> query = (from PRODUCTOSXCOMERCIO p in context.PRODUCTOSXCOMERCIO
                                               select p);
            foreach (var comercio in query)
            {
                resp = comercio.ID;
            }

            return resp;
        }

        public void Delete(int id)
        {
            var productosxcomercio = context.PRODUCTOSXCOMERCIO.Find(id);
            context.PRODUCTOSXCOMERCIO.Remove(productosxcomercio);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IPRODUCTOSXCOMERCIORepository : IDisposable
    {
        IQueryable<PRODUCTOSXCOMERCIO> All { get; }
        IQueryable<PRODUCTOSXCOMERCIO> AllIncluding(params Expression<Func<PRODUCTOSXCOMERCIO, object>>[] includeProperties);
        PRODUCTOSXCOMERCIO Find(int id);
        void InsertOrUpdate(PRODUCTOSXCOMERCIO productosxcomercio);
        void DeleteAllProductosComercio(int idComercio);
        void DeleteAllComercioProductos(int idProducto);
        void Delete(int id);
        void Save();
    }
}