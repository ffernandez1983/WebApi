using AutoMapper;
using Backend.Common.AutoMapperCustomConfiguration;
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
        private readonly IAutoMapperCustom _autoMapperCustom = null;

        public PostUsuarioController(IPostUsuarioService usuariosService, IAutoMapperCustom autoMapperCustom)
        {
            if (usuariosService == null)
            {
                throw new ArgumentNullException("usuariosService");
            }
            if (autoMapperCustom == null)
            {
                throw new ArgumentNullException("autoMapperCustom");
            }
            _usuariosService = usuariosService;
            _autoMapperCustom = autoMapperCustom;
        }

        /// <summary>
        /// Dar de alta un proveedor
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nuevo", Name = "PostUsuarioV1")]
        public async Task<HttpResponseMessage> PostUsuarioAsync([FromBody] VMUsuario newUsuario)
        {
            _autoMapperCustom.InicilizarMapper();
            var oldUsuario = new Usuario();

            var copiaUsuario = Mapper.Map<VMUsuario, Usuario>(newUsuario);
          

            HttpResponse<Usuario> status = await _usuariosService.PostUsuarioAsync(copiaUsuario);
            return Request.CreateResponse(status.Status, status.Entity);
        }
    }
}
