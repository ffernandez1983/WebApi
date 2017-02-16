using AutoMapper;
using Backend.Entities.Productos;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Productos")]
    public class PutProductosController : ApiController
    {
        private readonly IPutProductosService _productosService = null;

        public PutProductosController(IPutProductosService productosService)
        {
            if (productosService == null)
            {
                throw new ArgumentNullException("productosService");
            }
            _productosService = productosService;
        }

        /// <summary>
        /// Actualiza el producto
        /// </summary>
        /// <returns>OK</returns>
        [Route("Actualiza", Name = "")]
        public async Task<HttpResponseMessage> PutProductoAsync([FromBody] VMProducto newProducto, int idProducto)
        {
            var oldProducto = Mapper.Map<VMProducto, Producto>(newProducto);
            HttpResponse<Producto> status = await _productosService.PutProductoAsync(oldProducto, idProducto);
            return Request.CreateResponse(status.Status, status.Entity);
        }

    }
}

