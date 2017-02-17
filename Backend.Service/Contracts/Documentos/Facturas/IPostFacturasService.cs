using Backend.Entities.DatosCliente;
using Backend.Entities.Facturacion;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IPostFacturasService
    {
        Task<HttpResponse<Factura>> PostFacturaAsync(Factura factura);
        Task<HttpResponse<LineaFactura>> PostLineaFacturaAsync(LineaFactura lineafactura);

    }
}
