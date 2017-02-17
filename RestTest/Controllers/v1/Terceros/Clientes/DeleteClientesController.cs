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
    public class DeleteClientesController : ApiController
    {
        private readonly IDeleteClientesService _clientesService = null;

        public DeleteClientesController(IDeleteClientesService clientesService)
        {
            if(clientesService == null)
            {
                throw new ArgumentNullException("clientesService");
            }
            _clientesService = clientesService;
        }

        /// <summary>
        /// Borra el cliente
        /// </summary>
        /// <returns>OK</returns>
        [Route("Borra", Name = "DeleteClienteV1")]
        public async Task<HttpResponseMessage> DeleteClienteAsync(int idCliente)
        {
            
            HttpResponse<Cliente> status = await _clientesService.DeleteClienteAsync(idCliente);
            return Request.CreateResponse(status.Status, status.Entity);
        }



    }
}
