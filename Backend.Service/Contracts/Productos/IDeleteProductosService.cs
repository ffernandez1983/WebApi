using Backend.Entities.Productos;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IDeleteProductosService
    {
        Task<HttpResponse<Producto>> DeleteProductoAsync(int idProducto);


    }
}
