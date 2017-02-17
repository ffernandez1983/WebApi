using Backend.Entities.Facturacion;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPostAlbaranesService
    {
        Task<HttpResponse<Albaran>> PostAlbaranAsync(Albaran albaran);
        Task<HttpResponse<LineaAlbaran>> PostLineaAlbaranAsync(LineaAlbaran lineaalbaran);

    }
}
