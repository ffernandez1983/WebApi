using Backend.Entities.Facturacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IGetAlbaranesService
    {
        Task<List<Albaran>> GetTodosAlbaranes();
    }
}
