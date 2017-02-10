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
    //[ApiVersion1RoutePrefix("Clientes")]
    //public class PostClientesController : ApiController
    //{
    //    private readonly IPostClientesService _clientesService = null;

    //    public PostClientesController(IPostClientesService clientesService)
    //    {
    //        if(clientesService == null)
    //        {
    //            throw new ArgumentNullException("clientesService");
    //        }
    //        _clientesService = clientesService;
    //    }

    //    /// <summary>
    //    /// Prueba de comuncacion
    //    /// </summary>
    //    /// <returns>OK</returns>
    //    [Route("PruebaPost", Name = "PostPruebaV1")]
    //    public bool GetPrueba()
    //    {
    //        return true;
    //    }

    //    /// <summary>
    //    /// Dar de alta un cliente
    //    /// </summary>
    //    /// <returns>OK, Conflict</returns>
    //    [Route("PruebaPost", Name = "PostClienteV1")]
    //    public async Task<HttpResponseMessage> PostClienteAsync([FromBody] VMCliente newCliente)
    //    {
    //        Cliente oldCliente = new Cliente();
    //        oldCliente.Nombre = newCliente.Nombre;

    //        HttpResponse<Cliente> status = await _clientesService.PostClienteAsync(oldCliente);
    //        return Request.CreateResponse(status.Status, status.Entity);
    //    }

}
