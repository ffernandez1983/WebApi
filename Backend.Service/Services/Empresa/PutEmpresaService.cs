using Backend.Context;
using Backend.Entities.DatosEmpresa;
using Backend.Service.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class PutEmpresaService : IPutEmpresaService

    {
        public PutEmpresaService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Empresa>> PutEmpresaAsync(Empresa empresa, int idEmpresa)
        {            
            var empresaBusqueda = await ctx.Empresas.Where(e => e.IDEmpresa == idEmpresa).SingleOrDefaultAsync();
            empresaBusqueda.Nombre = empresa.Nombre;
            empresaBusqueda.Albaranes = empresa.Albaranes;
            

            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Empresa> { Status = HttpStatusCode.OK, Entity = empresa };
            return response;

        }

    }
}
