using Backend.Entities.DatosEmpresa;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPostEmpresaService
    {
        Task<HttpResponse<Empresa>> PostEmpresaAsync(Empresa empresa);

    }
}
