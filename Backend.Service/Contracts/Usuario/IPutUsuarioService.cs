using Backend.Entities.DatosUsuario;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPutUsuarioService
    {
        Task<HttpResponse<Usuario>> PutUsuarioAsync(Usuario usuario, int idUsuario);


    }
}
