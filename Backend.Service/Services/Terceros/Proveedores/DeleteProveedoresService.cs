using Backend.Context;
using Backend.Entities.DatosProveedor;
using Backend.Service.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class DeleteProveedoresService : IDeleteProveedoresService

    {
        public DeleteProveedoresService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Proveedor>> DeleteProveedorAsync(int idProveedor)
        {            
            var proveedorBusqueda = await ctx.Proveedores.Where(e => e.IDProveedor == idProveedor).SingleOrDefaultAsync();

            var response = new HttpResponse<Proveedor> { Status = HttpStatusCode.BadRequest, Entity = proveedorBusqueda };

            if (proveedorBusqueda != null)
            {
                ctx.Proveedores.Remove(proveedorBusqueda);

                await ctx.SaveChangesAsync();
                response = new HttpResponse<Proveedor> { Status = HttpStatusCode.OK, Entity = proveedorBusqueda };
            }

            else
            {
                response = new HttpResponse<Proveedor> { Status = HttpStatusCode.Conflict, Entity = proveedorBusqueda };
            }
            
            return response;

        }

    }
}
