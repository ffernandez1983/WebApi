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
    public class PutClientesService : IPutClientesService

    {
        public PutClientesService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Cliente>> PutClienteAsync(Cliente cliente, int idCliente)
        {
            var clienteBusqueda = await ctx.Clientes.Where(e => e.IDCliente == idCliente).SingleOrDefaultAsync();

            clienteBusqueda.Nombre = cliente.Nombre;
            clienteBusqueda.Apellido1 = cliente.Apellido1;
            clienteBusqueda.Apellido2 = cliente.Apellido2;

            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Cliente> { Status = HttpStatusCode.OK, Entity = cliente };
            return response;

        }
    }
}
