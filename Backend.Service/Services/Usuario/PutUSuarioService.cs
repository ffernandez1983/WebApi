using Backend.Context;
using Backend.Entities.DatosUsuario;
using Backend.Service.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class PutUsuarioService : IPutUsuarioService

    {
        public PutUsuarioService(IUnitOfWork database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }
            ctx = database;
        }
        private readonly IUnitOfWork ctx = null;

        public async Task<HttpResponse<Usuario>> PutUsuarioAsync(Usuario usuario, int idUsuario)
        {            
            var usuarioBusqueda = await ctx.Usuarios.Where(e => e.IDUsuario == idUsuario).SingleOrDefaultAsync();
            usuarioBusqueda.Nombre = usuario.Nombre;
            usuarioBusqueda.Apellido1 = usuario.Apellido1;
            usuarioBusqueda.Apellido2 = usuario.Apellido2;
            usuarioBusqueda.DNI = usuario.DNI;
            usuarioBusqueda.Direccion = usuario.Direccion;
            usuarioBusqueda.CodigoPostal = usuario.CodigoPostal;





            await ctx.SaveChangesAsync();

            var response = new HttpResponse<Usuario> { Status = HttpStatusCode.OK, Entity = usuario };
            return response;

        }

    }
}
