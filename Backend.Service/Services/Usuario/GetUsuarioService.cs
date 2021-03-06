﻿using Backend.Context;
using Backend.Entities.DatosUsuario;
using Backend.Service;
using Backend.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class GetUsuarioService : IGetUsuarioService

    {
        public GetUsuarioService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<List<Usuario>> GetTodosUsuarios()
        {
            var query = await (from cl in ctx.Usuarios
                        select cl).ToListAsync();
            return query;
        }

        public async Task<Usuario> GetDatosUsuario(int idUsuario)
        {
            var query = await (from cl in ctx.Usuarios
                               where cl.IDUsuario == idUsuario
                               select cl).SingleOrDefaultAsync();
            return query;
        }
    }
}
