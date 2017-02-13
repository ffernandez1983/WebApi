using Backend.Context;
using Backend.Entities;
using Backend.Entities.DatosCliente;
using Backend.Entities.Productos;
using Backend.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class GetProductosService : IGetProductosService

    {
        public GetProductosService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<List<Producto>> GetTodosProductos()
        {
            var query = await (from cl in ctx.Productos
                        select cl).ToListAsync();
            return query;
        }
    }
}
