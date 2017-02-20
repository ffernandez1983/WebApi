using Backend.Entities.DatosCliente;
using Backend.Entities.DatosProveedor;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPostProveedoresService
    {
        Task<HttpResponse<Proveedor>> PostProveedorAsync(Proveedor proveedor);

    }
}
