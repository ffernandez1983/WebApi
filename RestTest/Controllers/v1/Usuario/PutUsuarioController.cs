using AutoMapper;
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

    [ApiVersion1RoutePrefix("Usuarios")]
    public class PutUsuariosController : ApiController
    {
        private readonly IPutUsuarioService _usuarioService = null;

        public PutUsuariosController(IPutUsuarioService usuarioService)
        {
            if (usuarioService == null)
            {
                throw new ArgumentNullException("usuarioService");
            }
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Actualiza la usuario
        /// </summary>
        /// <returns>OK</returns>
        [Route("Actualiza", Name = "PutUsuarioV1")]
        public async Task<HttpResponseMessage> PutUsuarioAsync([FromBody] VMUsuario newUsuario, int idUsuario)
        {
            var oldUsuario = Mapper.Map<VMUsuario, Usuario>(newUsuario);
            HttpResponse<Usuario> status = await _usuarioService.PutUsuarioAsync(oldUsuario, idUsuario);
            return Request.CreateResponse(status.Status, status.Entity);
        }

    }
}

