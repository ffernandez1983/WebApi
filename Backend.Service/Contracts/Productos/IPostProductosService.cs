using Backend.Entities.Productos;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPostProductosService
    {
        Task<HttpResponse<Producto>> PostProductoAsync(Producto producto);

    }
}
