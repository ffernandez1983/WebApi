using Backend.Entities.Productos;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPutProductosService
    {
        Task<HttpResponse<Producto>> PutProductoAsync(Producto producto, int idProducto);


    }
}
