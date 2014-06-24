using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class COMERCIOSRepository : ICOMERCIOSRepository
    {
        Entities context = new Entities();

        private readonly IPRODUCTOSXCOMERCIORepository productosXcomercioRepository = new PRODUCTOSXCOMERCIORepository();
        
        public IQueryable<COMERCIOS> All
        {
            get { return context.COMERCIOS; }
        }

        public IQueryable<COMERCIOS> AllIncluding(params Expression<Func<COMERCIOS, object>>[] includeProperties)
        {
            IQueryable<COMERCIOS> query = context.COMERCIOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public COMERCIOS Find(int id)
        {
            return context.COMERCIOS.Find(id);
        }

        public void InsertOrUpdate(COMERCIOS comercios)
        {
            if (comercios.ID_COMERCIO == default(int)) {
                // New entity
                comercios.ID_COMERCIO = getLastNumber() + 1;
                context.COMERCIOS.Add(comercios);
                context.SaveChanges();
            } else {
                // Existing entity
                context.Entry(comercios).State = EntityState.Modified;
            }
        }
        //devuelve los productos de un comercio
        public ICollection<PRODUCTOS> productosComercio(int idComercio)
        {
            ICollection<PRODUCTOS> listaProductos = new List<PRODUCTOS>();

            IQueryable<PRODUCTOSXCOMERCIO> query = (from PRODUCTOSXCOMERCIO p in context.PRODUCTOSXCOMERCIO
                                                    where p.ID_COMERCIO == idComercio
                                                    select p); 
            IPRODUCTOSRepository productosRepository = new PRODUCTOSRepository();

            foreach(var producto in query)
            {
                listaProductos.Add(productosRepository.Find(producto.ID_PRODUCTO));                    
            }


            return listaProductos;


        }

        public void Delete(int id)
        {
            var comercios = context.COMERCIOS.Find(id);
            context.COMERCIOS.Remove(comercios);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
        //recupera el ultimo registro de la base de datos  para los usuarios
        public int getLastNumber()
        {
            int resp = 0;
            IQueryable<COMERCIOS> comercios = (from COMERCIOS p in context.COMERCIOS
                                               select p);
            foreach (var comercio in comercios)
            {
                resp = comercio.ID_COMERCIO;
            }

            return resp;
        }

        public bool hasProductosByCondition(int comercioId, int condicionID)
        {
            bool result = false;
            //ICollection<PRODUCTOS> productosComercio = this.productosComercio(comercioId);
            foreach (var producto in (this.productosComercio(comercioId)))
            {
                if (producto.ID_TIPO == condicionID)
                {
                    result = true;
                    break;
                }
            }


            return result;
        }
    }

    public interface ICOMERCIOSRepository : IDisposable
    {
        IQueryable<COMERCIOS> All { get; }
        IQueryable<COMERCIOS> AllIncluding(params Expression<Func<COMERCIOS, object>>[] includeProperties);
        COMERCIOS Find(int id);
        void InsertOrUpdate(COMERCIOS comercios);
        ICollection<PRODUCTOS> productosComercio(int idComercio);
        bool hasProductosByCondition(int comercioId, int condicionID);
        int getLastNumber();
        void Delete(int id);
        void Save();
    }
}