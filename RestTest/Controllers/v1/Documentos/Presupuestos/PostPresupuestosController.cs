using AutoMapper;
using Backend.Common.AutoMapperCustomConfiguration;
using Backend.Entities.Facturacion;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Presupuestos")]
    public class PostPresupuestosController : ApiController
    {        
        private readonly IPostPresupuestosService _presupuestosService = null;
        private readonly IAutoMapperCustom _autoMapperCustom = null;

        public PostPresupuestosController(IPostPresupuestosService presupuestosService, IAutoMapperCustom autoMapperCustom)
        {
            if (presupuestosService == null)
            {
                throw new ArgumentNullException("presupuestoService");
            }
            if (autoMapperCustom == null)
            {
                throw new ArgumentNullException("autoMapperCustom");
            }
            _presupuestosService = presupuestosService;
            _autoMapperCustom = autoMapperCustom;
        }


        /// <summary>
        /// Dar de alta un Presupuesto
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nueva", Name = "PostPresupuestoV1")]
        public async Task<HttpResponseMessage> PostPresupuestoAsync([FromBody] VMPresupuesto newPresupuesto)
        {
            _autoMapperCustom.InicilizarMapper();
            var factura = new Presupuesto();

            var copiaPresupuesto = Mapper.Map<VMPresupuesto, Presupuesto>(newPresupuesto);

            HttpResponse<Presupuesto> status = await _presupuestosService.PostPresupuestoAsync(copiaPresupuesto);
            return Request.CreateResponse(status.Status, status.Entity);
        }

        /// <summary>
        /// Dar de alta una Linea de Presupuesto
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("NuevaLinea", Name = "PostLineaPresupuestoV1")]
        public async Task<HttpResponseMessage> PostLineaPresupuestoAsync([FromBody] VMLineaPresupuesto newLineaPresupuesto)
        {
            _autoMapperCustom.InicilizarMapper();
            var factura = new Presupuesto();

            var copiaLineaPresupuesto = Mapper.Map<VMLineaPresupuesto, LineaPresupuesto>(newLineaPresupuesto);

            HttpResponse<LineaPresupuesto> status = await _presupuestosService.PostLineaPresupuestoAsync(copiaLineaPresupuesto);
            return Request.CreateResponse(status.Status, status.Entity);
        }




    }
}
