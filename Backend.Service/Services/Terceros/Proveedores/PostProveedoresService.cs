using Backend.Context;
using Backend.Service.Contracts;
using System;
using Backend.Entities.DatosCliente;
using System.Threading.Tasks;
using System.Net;

namespace Backend.Service
{
    public class PostProveedoresService : IPostProveedoresService

    {
        public PostProveedoresService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Proveedor>> PostProveedorAsync(Proveedor proveedor)
        {
           
            ctx.Proveedores.Add(proveedor);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Proveedor> { Status = HttpStatusCode.Created, Entity = proveedor };
            return response;

        }
    }
}
