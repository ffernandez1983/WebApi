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
    [ApiVersion1RoutePrefix("Pedidos")]
    public class PostPedidosController : ApiController
    {        
        private readonly IPostPedidosService _pedidosService = null;
        private readonly IAutoMapperCustom _autoMapperCustom = null;

        public PostPedidosController(IPostPedidosService pedidosService, IAutoMapperCustom autoMapperCustom)
        {
            if (pedidosService == null)
            {
                throw new ArgumentNullException("presupuestoService");
            }
            if (autoMapperCustom == null)
            {
                throw new ArgumentNullException("autoMapperCustom");
            }
            _pedidosService = pedidosService;
            _autoMapperCustom = autoMapperCustom;
        }


        /// <summary>
        /// Dar de alta un Pedido
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nueva", Name = "PostPedidoV1")]
        public async Task<HttpResponseMessage> PostPedidoAsync([FromBody] VMPedido newPedido)
        {
            _autoMapperCustom.InicilizarMapper();
            var pedido = new Pedido();

            var copiaPedido = Mapper.Map<VMPedido, Pedido>(newPedido);

            HttpResponse<Pedido> status = await _pedidosService.PostPedidoAsync(copiaPedido);
            return Request.CreateResponse(status.Status, status.Entity);
        }

        /// <summary>
        /// Dar de alta una Linea de Pedido
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("NuevaLinea", Name = "PostLineaPedidoV1")]
        public async Task<HttpResponseMessage> PostLineaPedidoAsync([FromBody] VMLineaPedido newLineaPedido)
        {
            _autoMapperCustom.InicilizarMapper();
            var pedido = new Pedido();

            var copiaLineaPedido = Mapper.Map<VMLineaPedido, LineaPedido>(newLineaPedido);

            HttpResponse<LineaPedido> status = await _pedidosService.PostLineaPedidoAsync(copiaLineaPedido);
            return Request.CreateResponse(status.Status, status.Entity);
        }




    }
}
