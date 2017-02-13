using Backend.Entities.DatosCliente;
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
    public class PostProductosController : ApiController
    {
        private readonly IPostProductosService _productosService = null;

        public PostProductosController(IPostProductosService productosService)
        {
            if (productosService == null)
            {
                throw new ArgumentNullException("clientesService");
            }
            _productosService = productosService;
        }

        /// <summary>
        /// Dar de alta un proveedor
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nuevo", Name = "PostProductoV1")]
        public async Task<HttpResponseMessage> PostProductoAsync([FromBody] VMProducto newProducto)
        {
            Producto oldProducto = new Producto();
            oldProducto.Nombre = newProducto.Nombre;

            HttpResponse<Producto> status = await _productosService.PostProductoAsync(oldProducto);
            return Request.CreateResponse(status.Status, status.Entity);
        }
    }
}
