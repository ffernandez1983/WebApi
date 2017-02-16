using AutoMapper;
using Backend.Entities;
using Backend.Entities.DatosCliente;
using Backend.Service;
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
    public class PutClientesController : ApiController
    {
        private readonly IPutClientesService _clientesService = null;

        public PutClientesController(IPutClientesService clientesService)
        {
            if(clientesService == null)
            {
                throw new ArgumentNullException("clientesService");
            }
            _clientesService = clientesService;
        }

        /// <summary>
        /// Actualiza el cliente
        /// </summary>
        /// <returns>OK</returns>
        [Route("Actualiza", Name = "PutClienteV1")]
        public async Task<HttpResponseMessage> PutClienteAsync([FromBody] VMCliente newCliente, int idCliente)
        {
            var oldCliente = Mapper.Map<VMCliente, Cliente>(newCliente);


            HttpResponse<Cliente> status = await _clientesService.PutClienteAsync(oldCliente, idCliente);
            return Request.CreateResponse(status.Status, status.Entity);
        }



    }
}
