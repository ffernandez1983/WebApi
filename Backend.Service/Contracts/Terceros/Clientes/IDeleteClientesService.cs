using Backend.Entities.DatosCliente;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IDeleteClientesService
    {
        Task<HttpResponse<Cliente>> DeleteClienteAsync(int idCliente);


    }
}
