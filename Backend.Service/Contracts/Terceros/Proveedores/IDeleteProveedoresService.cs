using Backend.Entities.DatosProveedor;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IDeleteProveedoresService
    {
        Task<HttpResponse<Proveedor>> DeleteProveedorAsync(int idProveedor);
    }
}
