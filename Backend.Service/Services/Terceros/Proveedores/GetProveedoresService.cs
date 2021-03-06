﻿using Backend.Context;
using Backend.Entities.DatosProveedor;
using Backend.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class GetProveedoresService: IGetProveedoresService

    {
        public GetProveedoresService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<List<Proveedor>> GetTodosProveedores()
        {
            var query = await (from cl in ctx.Proveedores
                        select cl).ToListAsync();
            return query;
        }
    }
}
