using Backend.Context;
using Backend.Service.Contracts;
using System;
using Backend.Entities.DatosCliente;
using System.Threading.Tasks;
using System.Net;
using Backend.Entities.Facturacion;

namespace Backend.Service
{
    public class PostPresupuestosService : IPostPresupuestosService

    {
        public PostPresupuestosService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Presupuesto>> PostPresupuestoAsync(Presupuesto presupuesto)
        {

            ctx.Presupuestos.Add(presupuesto);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Presupuesto> { Status = HttpStatusCode.Created, Entity = presupuesto };
            return response;

        }

        public async Task<HttpResponse<LineaPresupuesto>> PostLineaPresupuestoAsync(LineaPresupuesto lineapresupuesto)
        {

            ctx.LineasPresupuesto.Add(lineapresupuesto);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<LineaPresupuesto> { Status = HttpStatusCode.Created, Entity = lineapresupuesto };
            return response;

        }
    }
}
