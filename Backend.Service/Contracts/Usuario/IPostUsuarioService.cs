using Backend.Entities.DatosUsuario;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPostUsuarioService
    {
        Task<HttpResponse<Usuario>> PostUsuarioAsync(Usuario usuario);

    }
}
