using Backend.Entities.DatosUsuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IGetUsuarioService
    {
        Task<List<Usuario>> GetDatosUsuario();
    }
}
