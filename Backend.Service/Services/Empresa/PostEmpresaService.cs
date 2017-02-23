using Backend.Context;
using Backend.Entities.DatosEmpresa;
using Backend.Service.Contracts;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class PostEmpresasService : IPostEmpresaService

    {
        public PostEmpresasService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Empresa>> PostEmpresaAsync(Empresa empresa)
        {
           
            ctx.Empresas.Add(empresa);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Empresa> { Status = HttpStatusCode.Created, Entity = empresa };
            return response;

        }
    }
}
