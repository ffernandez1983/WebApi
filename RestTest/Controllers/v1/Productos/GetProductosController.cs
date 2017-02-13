using Backend.Entities.Productos;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Productos")]
    public class GetProductosController : ApiController
    {
        private readonly IGetProductosService _productosService = null;

        public GetProductosController(GetProductosService productosService)
        {
            if (productosService == null)
            {
                throw new ArgumentNullException("proveedoresService");
            }
            _productosService = productosService;
        }

        /// <summary>
        /// Obtenemos todos los proveedores
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [Route("Todos", Name = "GetProductosV1")]
        public async Task<List<Producto>> GetTodosProductos()
        {
            return await _productosService.GetTodosProductos();
        }

    }
}
