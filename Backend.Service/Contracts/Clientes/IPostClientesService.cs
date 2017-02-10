using Backend.Entities.DatosCliente;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPostClientesService
    {
        Task<HttpResponse<Cliente>> PostClienteAsync(Cliente cliente);

    }
}
