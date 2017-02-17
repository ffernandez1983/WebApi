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
    public class GetFacturasService:IGetFacturasService

    {
        public GetFacturasService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<List<Factura>> GetTodosFacturas()
        {
            var query = await (from fa in ctx.Facturas
                        select fa).ToListAsync();
            return query;
        }
    }
}
