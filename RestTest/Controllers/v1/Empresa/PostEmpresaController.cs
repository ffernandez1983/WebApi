using Backend.Entities.DatosEmpresa;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Empresa")]
    public class PostEmpresaController : ApiController
    {
        private readonly IPostEmpresaService _empresasService = null;

        public PostEmpresaController(IPostEmpresaService empresasService)
        {
            if (empresasService == null)
            {
                throw new ArgumentNullException("empresasService");
            }
            _empresasService = empresasService;
        }

        /// <summary>
        /// Dar de alta un proveedor
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nueva", Name = "PostEmpresaV1")]
        public async Task<HttpResponseMessage> PostEmpresaAsync([FromBody] VMEmpresa newEmpresa)
        {
            Empresa oldEmpresa = new Empresa();
            oldEmpresa.Nombre = newEmpresa.Nombre;

            HttpResponse<Empresa> status = await _empresasService.PostEmpresaAsync(oldEmpresa);
            return Request.CreateResponse(status.Status, status.Entity);
        }
    }
}
