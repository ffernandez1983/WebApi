using Backend.Entities.DatosUsuario;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Usuario")]
    public class GetUsuarioController : ApiController
    {
        private readonly IGetUsuarioService _usuariosService = null;

        public GetUsuarioController(GetUsuarioService usuariosService)
        {
            if (usuariosService == null)
            {
                throw new ArgumentNullException("usuariosService");
            }
            _usuariosService = usuariosService;
        }

        /// <summary>
        /// Obtenemos todos los usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [Route("Todos", Name = "GetUsuariosV1")]
        public async Task<List<Usuario>> GetTodosUsuarios()
        {
            return await _usuariosService.GetTodosUsuarios();
        }

        /// <summary>
        /// Obtenemos todos los proveedores
        /// </summary>
        /// <param name="idUsuario">id del usuario</param>
        /// <returns>Datos de un usuario</returns>
        [Route("Usuario", Name = "GetDatosUsuarioV1")]
        public async Task<Usuario> GetDatosUsuario(int idUsuario)
        {
            return await _usuariosService.GetDatosUsuario(idUsuario);
        }

    }
}
