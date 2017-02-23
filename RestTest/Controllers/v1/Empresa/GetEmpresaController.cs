using Backend.Entities.DatosEmpresa;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Empresa")]
    public class GetEmpresaController : ApiController
    {
        private readonly IGetEmpresaService _empresasService = null;

        public GetEmpresaController(GetEmpresaService empresasService)
        {
            if (empresasService == null)
            {
                throw new ArgumentNullException("empresasService");
            }
            _empresasService = empresasService;
        }

        /// <summary>
        /// Obtenemos todos los proveedores
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [Route("Todos", Name = "GetEmpresaV1")]
        public async Task<List<Empresa>> GetDatosEmpresa()
        {
            return await _empresasService.GetDatosEmpresa();
        }

    }
}
