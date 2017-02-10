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
        /// Prueba de comuncacion
        /// </summary>
        /// <returns>OK</returns>
        [Route("PruebaPut", Name = "PutPruebaV1")]
        public bool GetPrueba()
        {
            return true;
        }

     

    }
}
