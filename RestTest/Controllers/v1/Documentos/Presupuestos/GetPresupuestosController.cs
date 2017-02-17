using Backend.Entities.Facturacion;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Presupuestos")]
    public class GetPresupuestosController : ApiController
    {
        private readonly IGetPresupuestosService _presupuestosService = null;

        public GetPresupuestosController(IGetPresupuestosService presupuestosService)
        {
            if(presupuestosService == null)
            {
                throw new ArgumentNullException("presupuestosService");
            }
            _presupuestosService = presupuestosService;
        }
     
        /// <summary>
        /// Obtenemos todos los presupuestos
        /// </summary>
        /// <returns>Lista de presupuestos</returns>
        [Route("Todos", Name = "GetPresupuestosV1")]
        public async Task<List<Presupuesto>> GetTodosPresupuestos()
        {
            return await _presupuestosService.GetTodosPresupuestos();
        }

    }
}
