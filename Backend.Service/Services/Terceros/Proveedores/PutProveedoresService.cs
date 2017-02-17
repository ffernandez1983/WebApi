using Backend.Context;
using Backend.Entities.DatosCliente;
using Backend.Service.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class PutProveedoresService : IPutProveedoresService

    {
        public PutProveedoresService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Proveedor>> PutProveedorAsync(Proveedor proveedor, int idProveedor)
        {
            var proveedorBusqueda = await ctx.Proveedores.Where(e => e.IDProveedor == idProveedor).SingleOrDefaultAsync();

            proveedorBusqueda.Nombre = proveedor.Nombre;
            proveedorBusqueda.Apellido1 = proveedor.Apellido1;
            proveedorBusqueda.Apellido2 = proveedor.Apellido2;

            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Proveedor> { Status = HttpStatusCode.OK, Entity = proveedor };
            return response;

        }
    }
}
