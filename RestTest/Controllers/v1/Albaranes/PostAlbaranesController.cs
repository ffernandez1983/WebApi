using AutoMapper;
using Backend.Common.AutoMapperCustomConfiguration;
using Backend.Entities.Facturacion;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Common.Routing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace RestTest.Controllers.v1
{
    [ApiVersion1RoutePrefix("Albaranes")]
    public class PostAlbaranesController : ApiController
    {        
        private readonly IPostAlbaranesService _albaranesService = null;
        private readonly IAutoMapperCustom _autoMapperCustom = null;

        public PostAlbaranesController(IPostAlbaranesService albaranesService, IAutoMapperCustom autoMapperCustom)
        {
            if(albaranesService == null)
            {
                throw new ArgumentNullException("clientesService");
            }
            if (autoMapperCustom == null)
            {
                throw new ArgumentNullException("autoMapperCustom");
            }
            _albaranesService = albaranesService;
            _autoMapperCustom = autoMapperCustom;
        }
     

        /// <summary>
        /// Dar de alta una Albaran
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("Nueva", Name = "PostAlbaranV1")]
        public async Task<HttpResponseMessage> PostAlbaranAsync([FromBody] VMAlbaran newAlbaran)
        {
            _autoMapperCustom.InicilizarMapper();
            var albaran = new Albaran();

            var copiaAlbaran = Mapper.Map<VMAlbaran, Albaran>(newAlbaran);

            HttpResponse<Albaran> status = await _albaranesService.PostAlbaranAsync(copiaAlbaran);
            return Request.CreateResponse(status.Status, status.Entity);
        }

        /// <summary>
        /// Dar de alta una Linea de Albaran
        /// </summary>
        /// <returns>OK, Conflict</returns>
        [Route("NuevaLinea", Name = "PostLineaAlbaranV1")]
        public async Task<HttpResponseMessage> PostLineaAlbaranAsync([FromBody] VMLineaAlbaran newLineaAlbaran)
        {
            _autoMapperCustom.InicilizarMapper();
            var albaran = new Albaran();

            var copiaLineaAlbaran = Mapper.Map<VMLineaAlbaran, LineaAlbaran>(newLineaAlbaran);

            HttpResponse<LineaAlbaran> status = await _albaranesService.PostLineaAlbaranAsync(copiaLineaAlbaran);
            return Request.CreateResponse(status.Status, status.Entity);
        }




    }
}
