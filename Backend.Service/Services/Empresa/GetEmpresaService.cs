using Backend.Context;
using Backend.Entities.DatosEmpresa;
using Backend.Service;
using Backend.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class GetEmpresaService : IGetEmpresaService

    {
        public GetEmpresaService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<List<Empresa>> GetDatosEmpresa()
        {
            var query = await (from cl in ctx.Empresas
                        select cl).ToListAsync();
            return query;
        }
    }
}
