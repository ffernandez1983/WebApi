using Backend.Entities.Facturacion;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Albaranes")]
    public class GetAlbaranesController : ApiController
    {
        private readonly IGetAlbaranesService _albaranesService = null;

        public GetAlbaranesController(IGetAlbaranesService albaranesService)
        {
            if(albaranesService == null)
            {
                throw new ArgumentNullException("albaranesService");
            }
            _albaranesService = albaranesService;
        }
     
        /// <summary>
        /// Obtenemos todos los albaranes
        /// </summary>
        /// <returns>Lista de albaranes</returns>
        [Route("Todos", Name = "GetAlbaranesV1")]
        public async Task<List<Albaran>> GetTodosAlbaranes()
        {
            return await _albaranesService.GetTodosAlbaranes();
        }

    }
}
