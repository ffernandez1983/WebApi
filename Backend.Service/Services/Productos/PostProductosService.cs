using Backend.Context;
using Backend.Service.Contracts;
using System;
using Backend.Entities.DatosCliente;
using System.Threading.Tasks;
using System.Net;
using Backend.Entities.Productos;

namespace Backend.Service
{
    public class PostProductosService : IPostProductosService

    {
        public PostProductosService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Producto>> PostProductoAsync(Producto producto)
        {
           
            ctx.Productos.Add(producto);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Producto> { Status = HttpStatusCode.Created, Entity = producto };
            return response;

        }
    }
}
