using Backend.Context;
using Backend.Entities.Facturacion;
using Backend.Service.Contracts;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class PostAlbaranesService : IPostAlbaranesService

    {
        public PostAlbaranesService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Albaran>> PostAlbaranAsync(Albaran albaran)
        {
           
            ctx.Albaranes.Add(albaran);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Albaran> { Status = HttpStatusCode.Created, Entity = albaran };
            return response;

        }

        public async Task<HttpResponse<LineaAlbaran>> PostLineaAlbaranAsync(LineaAlbaran lineaalbaran)
        {

            ctx.LineasAlbaran.Add(lineaalbaran);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<LineaAlbaran> { Status = HttpStatusCode.Created, Entity = lineaalbaran };
            return response;

        }
    }
}
