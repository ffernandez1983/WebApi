using Backend.Entities.Productos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IGetProductosService
    {
        Task<List<Producto>> GetTodosProductos();
    }
}
