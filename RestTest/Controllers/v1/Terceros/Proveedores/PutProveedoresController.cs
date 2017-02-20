using AutoMapper;
using Backend.Entities.DatosProveedor;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Proveedores")]
    public class PutProveedoresController : ApiController
    {
        private readonly IPutProveedoresService _proveedoresService = null;

        public PutProveedoresController(IPutProveedoresService proveedoresService)
        {
            if (proveedoresService == null)
            {
                throw new ArgumentNullException("proveedoresService");
            }
            _proveedoresService = proveedoresService;
        }

        /// <summary>
        /// Actualiza el proveedor
        /// </summary>
        /// <returns>OK</returns>
        [Route("Actualiza", Name = "PutProveedorV1")]
        public async Task<HttpResponseMessage> PutProveedorAsync([FromBody] VMProveedor newProveedor, int idProveedor)
        {
            var oldProveedor = Mapper.Map<VMProveedor, Proveedor>(newProveedor);


            HttpResponse<Proveedor> status = await _proveedoresService.PutProveedorAsync(oldProveedor, idProveedor);
            return Request.CreateResponse(status.Status, status.Entity);
        }



    }
}
