using Backend.Entities.DatosEmpresa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IGetEmpresaService
    {
        Task<List<Empresa>> GetDatosEmpresa();
    }
}
