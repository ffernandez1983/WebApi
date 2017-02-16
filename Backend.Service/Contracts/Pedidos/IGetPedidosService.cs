using Backend.Entities.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IGetPedidosService
    {
        Task<List<Pedido>> GetTodosPedidos();
    }
}
