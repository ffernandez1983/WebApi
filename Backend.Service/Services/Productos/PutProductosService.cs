using Backend.Context;
using Backend.Entities.Productos;
using Backend.Service.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class PutProductosService : IPutProductosService

    {
        public PutProductosService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Producto>> PutProductoAsync(Producto producto, int idProducto)
        {            
            var productoBusqueda = await ctx.Productos.Where(e => e.IDProducto == idProducto).SingleOrDefaultAsync();
            productoBusqueda.Nombre = producto.Nombre;
            productoBusqueda.Descripcion = producto.Descripcion;
            productoBusqueda.Precio = producto.Precio;

            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Producto> { Status = HttpStatusCode.OK, Entity = producto };
            return response;

        }

    }
}
