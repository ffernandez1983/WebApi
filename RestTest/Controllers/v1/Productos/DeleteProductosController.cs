
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
    public class DeleteProductosController : ApiController
    {
        private readonly IDeleteProductosService _productosService = null;

        public DeleteProductosController(IDeleteProductosService productosService)
        {
            if(productosService == null)
            {
                throw new ArgumentNullException("productosService");
            }
            _productosService = productosService;
        }

        /// <summary>
        /// Borra el producto
        /// </summary>
        /// <returns>OK</returns>
        [Route("Borra", Name = "DeleteProductoV1")]
        public async Task<HttpResponseMessage> DeleteProductoAsync(int idProducto)
        {
            
            HttpResponse<Producto> status = await _productosService.DeleteProductoAsync(idProducto);
            return Request.CreateResponse(status.Status, status.Entity);
        }



    }
}
