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
    public class GetPresupuestosService:IGetPresupuestosService

    {
        public GetPresupuestosService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<List<Presupuesto>> GetTodosPresupuestos()
        {
            var query = await (from pe in ctx.Presupuestos
                        select pe).ToListAsync();
            return query;
        }
    }
}
