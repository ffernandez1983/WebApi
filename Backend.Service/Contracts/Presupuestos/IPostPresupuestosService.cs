using Backend.Entities.DatosCliente;
using Backend.Entities.Facturacion;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPostPresupuestosService
    {
        Task<HttpResponse<Presupuesto>> PostPresupuestoAsync(Presupuesto factura);
        Task<HttpResponse<LineaPresupuesto>> PostLineaPresupuestoAsync(LineaPresupuesto lineapresupuesto);

    }
}
