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
    public class DeleteClientesService : IDeleteClientesService

    {
        public DeleteClientesService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Cliente>> DeleteClienteAsync(int idCliente)
        {            
            var clienteBusqueda = await ctx.Clientes.Where(e => e.IDCliente == idCliente).SingleOrDefaultAsync();

            var response = new HttpResponse<Cliente> { Status = HttpStatusCode.BadRequest, Entity = clienteBusqueda };

            if (clienteBusqueda != null)
            {
                ctx.Clientes.Remove(clienteBusqueda);

                await ctx.SaveChangesAsync();
                response = new HttpResponse<Cliente> { Status = HttpStatusCode.OK, Entity = clienteBusqueda };
            }

            else
            {
                response = new HttpResponse<Cliente> { Status = HttpStatusCode.Conflict, Entity = clienteBusqueda };
            }
            
            return response;

        }

    }
}
