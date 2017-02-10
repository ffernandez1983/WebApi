using AutoMapper;
using Backend.Common.AutoMapperCustomConfiguration;
using Backend.Entities.Facturacion;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Facturas")]
    public class PostFacturasController : ApiController
    {        
        private readonly IPostFacturasService _facturasService = null;
        private readonly IAutoMapperCustom _autoMapperCustom = null;

        public PostFacturasController(IPostFacturasService facturasService, IAutoMapperCustom autoMapperCustom)
        {
            if(facturasService == null)
            {
                throw new ArgumentNullException("clientesService");
            }
            if (autoMapperCustom == null)
            {
                throw new ArgumentNullException("autoMapperCustom");
            }
            _facturasService = facturasService;
            _autoMapperCustom = autoMapperCustom;
        }
     

        /// <summary>
        /// Dar de alta una Factura
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nueva", Name = "PostFacturaV1")]
        public async Task<HttpResponseMessage> PostClienteAsync([FromBody] VMFactura newFactura)
        {
            _autoMapperCustom.InicilizarMapper();
            var factura = new Factura();

            var copiaFactura = Mapper.Map<VMFactura, Factura>(newFactura);

            HttpResponse<Factura> status = await _facturasService.PostFacturaAsync(copiaFactura);
            return Request.CreateResponse(status.Status, status.Entity);
        }

        

       
    }
}
