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
    public class GetAlbaranesService:IGetAlbaranesService

    {
        public GetAlbaranesService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<List<Albaran>> GetTodosAlbaranes()
        {
            var query = await (from al in ctx.Albaranes
                        select al).ToListAsync();
            return query;
        }
    }
}
