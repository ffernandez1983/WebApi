using Backend.Entities.DatosCliente;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Proveedores")]
    public class GetProveedoresController : ApiController
    {
        private readonly IGetProveedoresService _proveedoresService = null;

        public GetProveedoresController(GetProveedoresService proveedoresService)
        {
            if (proveedoresService == null)
            {
                throw new ArgumentNullException("proveedoresService");
            }
            _proveedoresService = proveedoresService;
        }

        /// <summary>
        /// Obtenemos todos los proveedores
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [Route("Todos", Name = "GetProveedoresV1")]
        public async Task<List<Proveedor>> GetTodosProveedores()
        {
            return await _proveedoresService.GetTodosProveedores();
        }

    }
}
