using Backend.Context;
using Backend.Entities;
using Backend.Entities.DatosCliente;
using Backend.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class PutClientesService : IPutClientesService

    {
        public PutClientesService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;
      
    }
}
