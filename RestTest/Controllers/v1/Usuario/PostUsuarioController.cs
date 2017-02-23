using Backend.Entities.DatosUsuario;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Usuario")]
    public class PostUsuarioController : ApiController
    {
        private readonly IPostUsuarioService _usuariosService = null;

        public PostUsuarioController(IPostUsuarioService usuariosService)
        {
            if (usuariosService == null)
            {
                throw new ArgumentNullException("usuariosService");
            }
            _usuariosService = usuariosService;
        }

        /// <summary>
        /// Dar de alta un proveedor
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nueva", Name = "PostUsuarioV1")]
        public async Task<HttpResponseMessage> PostUsuarioAsync([FromBody] VMUsuario newUsuario)
        {
            Usuario oldUsuario = new Usuario();
            oldUsuario.Nombre = newUsuario.Nombre;

            HttpResponse<Usuario> status = await _usuariosService.PostUsuarioAsync(oldUsuario);
            return Request.CreateResponse(status.Status, status.Entity);
        }
    }
}
