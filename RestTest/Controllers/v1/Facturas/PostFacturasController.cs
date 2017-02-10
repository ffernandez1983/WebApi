using AutoMapper;
using Backend.Entities;
using Backend.Entities.DatosCliente;
using Backend.Entities.Facturacion;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Facturas")]
    public class PostFacturasController : ApiController
    {
        private readonly IPostFacturasService _facturasService = null;

        public PostFacturasController(IPostFacturasService facturasService)
        {
            if(facturasService == null)
            {
                throw new ArgumentNullException("clientesService");
            }
            _facturasService = facturasService;
        }
     

        /// <summary>
        /// Dar de alta una Factura
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nueva", Name = "PostFacturaV1")]
        public async Task<HttpResponseMessage> PostClienteAsync([FromBody] VMFactura newFactura)
        {
            Factura oldFactura = new Factura();
            Mapper.Map(newFactura, oldFactura);          

            HttpResponse<Factura> status = await _facturasService.PostFacturaAsync(oldFactura);
            return Request.CreateResponse(status.Status, status.Entity);
        }

    }
}
