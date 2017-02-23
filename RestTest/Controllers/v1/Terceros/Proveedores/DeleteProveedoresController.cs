using AutoMapper;
using Backend.Entities;
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
    public class DeleteProveedoresController : ApiController
    {
        private readonly IDeleteProveedoresService _proveedoresService = null;

        public DeleteProveedoresController(IDeleteProveedoresService proveedoresService)
        {
            if(proveedoresService == null)
            {
                throw new ArgumentNullException("proveedoresService");
            }
            _proveedoresService = proveedoresService;
        }

        /// <summary>
        /// Borra el proveedor
        /// </summary>
        /// <returns>OK</returns>
        [Route("Borra", Name = "DeleteProveedorV1")]
        public async Task<HttpResponseMessage> DeleteProveedorAsync(int idProveedor)
        {
            
            HttpResponse<Proveedor> status = await _proveedoresService.DeleteProveedorAsync(idProveedor);
            return Request.CreateResponse(status.Status, status.Entity);
        }



    }
}
