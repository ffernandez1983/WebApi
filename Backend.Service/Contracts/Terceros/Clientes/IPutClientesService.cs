using Backend.Entities.DatosCliente;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPutClientesService
    {
        Task<HttpResponse<Cliente>> PutClienteAsync(Cliente cliente, int idCliente);
    }
}
