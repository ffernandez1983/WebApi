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
        /// Obtenemos todos los proveedores
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [Route("Todos", Name = "GetUsuarioV1")]
        public async Task<List<Usuario>> GetDatosUsuario()
        {
            return await _usuariosService.GetDatosUsuario();
        }

    }
}
