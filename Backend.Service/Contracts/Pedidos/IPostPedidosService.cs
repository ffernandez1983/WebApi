using Backend.Entities.Facturacion;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPostPedidosService
    {
        Task<HttpResponse<Pedido>> PostPedidoAsync(Pedido factura);
        Task<HttpResponse<LineaPedido>> PostLineaPedidoAsync(LineaPedido lineafactura);

    }
}
