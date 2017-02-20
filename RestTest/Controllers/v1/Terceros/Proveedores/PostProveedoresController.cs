using AutoMapper;
using Backend.Entities;
using Backend.Entities.DatosCliente;
using Backend.Entities.DatosProveedor;
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
    [ApiVersion1RoutePrefix("Proveedores")]
    public class PostProveedoresController : ApiController
    {
        private readonly IPostProveedoresService _proveedoresService = null;

        public PostProveedoresController(IPostProveedoresService proveedoresService)
        {
            if (proveedoresService == null)
            {
                throw new ArgumentNullException("clientesService");
            }
            _proveedoresService = proveedoresService;
        }

        /// <summary>
        /// Dar de alta un proveedor
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nuevo", Name = "PostProveedorV1")]
        public async Task<HttpResponseMessage> PostProveedorAsync([FromBody] VMProveedor newProveedor)
        {
            Proveedor oldProveedor = new Proveedor();
            oldProveedor.Nombre = newProveedor.Nombre;

            HttpResponse<Proveedor> status = await _proveedoresService.PostProveedorAsync(oldProveedor);
            return Request.CreateResponse(status.Status, status.Entity);
        }
    }
}
