using Backend.Context;
using Backend.Entities.Facturacion;
using Backend.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class GetPedidosService:IGetPedidosService

    {
        public GetPedidosService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<List<Pedido>> GetTodosPedidos()
        {
            var query = await (from pe in ctx.Pedidos
                        select pe).ToListAsync();
            return query;
        }
    }
}
