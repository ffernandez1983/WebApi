using Backend.Entities.Facturacion;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Pedidos")]
    public class GetPedidosController : ApiController
    {
        private readonly IGetPedidosService _pedidosService = null;

        public GetPedidosController(IGetPedidosService pedidosService)
        {
            if(pedidosService == null)
            {
                throw new ArgumentNullException("pedidosService");
            }
            _pedidosService = pedidosService;
        }
     
        /// <summary>
        /// Obtenemos todos los pedidos
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        [Route("Todos", Name = "GetPedidosV1")]
        public async Task<List<Pedido>> GetTodosPedidos()
        {
            return await _pedidosService.GetTodosPedidos();
        }

    }
}
