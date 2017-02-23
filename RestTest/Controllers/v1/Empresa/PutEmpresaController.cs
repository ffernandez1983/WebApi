using AutoMapper;
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

    [ApiVersion1RoutePrefix("Empresas")]
    public class PutEmpresasController : ApiController
    {
        private readonly IPutEmpresaService _empresaService = null;

        public PutEmpresasController(IPutEmpresaService empresaService)
        {
            if (empresaService == null)
            {
                throw new ArgumentNullException("empresaService");
            }
            _empresaService = empresaService;
        }

        /// <summary>
        /// Actualiza la empresa
        /// </summary>
        /// <returns>OK</returns>
        [Route("Actualiza", Name = "PutEmpresaV1")]
        public async Task<HttpResponseMessage> PutEmpresaAsync([FromBody] VMEmpresa newEmpresa, int idEmpresa)
        {
            var oldEmpresa = Mapper.Map<VMEmpresa, Empresa>(newEmpresa);
            HttpResponse<Empresa> status = await _empresaService.PutEmpresaAsync(oldEmpresa, idEmpresa);
            return Request.CreateResponse(status.Status, status.Entity);
        }

    }
}

