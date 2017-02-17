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
    public class DeleteProductosService : IDeleteProductosService

    {
        public DeleteProductosService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Producto>> DeleteProductoAsync(int idProducto)
        {            
            var productoBusqueda = await ctx.Productos.Where(e => e.IDProducto == idProducto).SingleOrDefaultAsync();

            var response = new HttpResponse<Producto> { Status = HttpStatusCode.BadRequest, Entity = productoBusqueda };

            if (productoBusqueda != null)
            {
                ctx.Productos.Remove(productoBusqueda);

                await ctx.SaveChangesAsync();
                response = new HttpResponse<Producto> { Status = HttpStatusCode.OK, Entity = productoBusqueda };
            }

            else
            {
                response = new HttpResponse<Producto> { Status = HttpStatusCode.Conflict, Entity = productoBusqueda };
            }
            
            return response;

        }

    }
}
