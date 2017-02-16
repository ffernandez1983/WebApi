using Backend.Context;
using Backend.Entities.Facturacion;
using Backend.Service.Contracts;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class PostPedidosService : IPostPedidosService

    {
        public PostPedidosService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Pedido>> PostPedidoAsync(Pedido pedido)
        {
           
            ctx.Pedidos.Add(pedido);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Pedido> { Status = HttpStatusCode.Created, Entity = pedido };
            return response;

        }

        public async Task<HttpResponse<LineaPedido>> PostLineaPedidoAsync(LineaPedido lineapedido)
        {

            ctx.LineasPedido.Add(lineapedido);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<LineaPedido> { Status = HttpStatusCode.Created, Entity = lineapedido };
            return response;

        }
    }
}
