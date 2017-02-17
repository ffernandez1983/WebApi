using Backend.Context;
using Backend.Service.Contracts;
using System;
using Backend.Entities.DatosCliente;
using System.Threading.Tasks;
using System.Net;
using Backend.Entities.Facturacion;

namespace Backend.Service
{
    public class PostFacturasService : IPostFacturasService

    {
        public PostFacturasService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Factura>> PostFacturaAsync(Factura factura)
        {
           
            ctx.Facturas.Add(factura);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Factura> { Status = HttpStatusCode.Created, Entity = factura };
            return response;

        }

        public async Task<HttpResponse<LineaFactura>> PostLineaFacturaAsync(LineaFactura lineafactura)
        {

            ctx.LineasFactura.Add(lineafactura);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<LineaFactura> { Status = HttpStatusCode.Created, Entity = lineafactura };
            return response;

        }
    }
}
