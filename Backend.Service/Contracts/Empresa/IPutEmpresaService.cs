using Backend.Entities.DatosEmpresa;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPutEmpresaService
    {
        Task<HttpResponse<Empresa>> PutEmpresaAsync(Empresa empresa, int idEmpresa);


    }
}
