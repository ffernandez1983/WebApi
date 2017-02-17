using Backend.Entities.Facturacion;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Facturas")]
    public class GetFacturasController : ApiController
    {
        private readonly IGetFacturasService _facturasService = null;

        public GetFacturasController(IGetFacturasService facturasService)
        {
            if(facturasService == null)
            {
                throw new ArgumentNullException("facturasService");
            }
            _facturasService = facturasService;
        }
     
        /// <summary>
        /// Obtenemos todos los facturas
        /// </summary>
        /// <returns>Lista de facturas</returns>
        [Route("Todos", Name = "GetFacturasV1")]
        public async Task<List<Factura>> GetTodosFacturas()
        {
            return await _facturasService.GetTodosFacturas();
        }

    }
}
