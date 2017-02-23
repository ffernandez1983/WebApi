using Backend.Context;
using Backend.Entities.DatosUsuario;
using Backend.Service.Contracts;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class PostUsuarioService : IPostUsuarioService

    {
        public PostUsuarioService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Usuario>> PostUsuarioAsync(Usuario usuario)
        {
           
            ctx.Usuarios.Add(usuario);
            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Usuario> { Status = HttpStatusCode.Created, Entity = usuario };
            return response;

        }
    }
}
