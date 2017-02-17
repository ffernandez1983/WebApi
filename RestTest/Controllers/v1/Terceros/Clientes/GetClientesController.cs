using Backend.Entities;
using Backend.Entities.DatosCliente;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Clientes")]
    public class GetClientesController : ApiController
    {
        private readonly IGetClientesService _clientesService = null;

        public GetClientesController(IGetClientesService clientesService)
        {
            if(clientesService == null)
            {
                throw new ArgumentNullException("clientesService");
            }
            _clientesService = clientesService;
        }
     
        /// <summary>
        /// Obtenemos todos los clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [Route("Todos", Name = "GetClientesV1")]
        public async Task<List<Cliente>> GetTodosClientes()
        {
            return await _clientesService.GetTodosClientes();
        }

    }
}
