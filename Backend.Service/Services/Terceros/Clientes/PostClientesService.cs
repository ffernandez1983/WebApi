using Backend.Context;
using Backend.Service.Contracts;
using System;
using Backend.Entities.DatosCliente;
using System.Threading.Tasks;
using System.Net;

namespace Backend.Service
{
    public class PostClientesService : IPostClientesService

    {
        public PostClientesService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Cliente>> PostClienteAsync(Cliente cliente)
        {
           
            ctx.Clientes.Add(cliente);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Cliente> { Status = HttpStatusCode.Created, Entity = cliente };
            return response;

        }
    }
}
