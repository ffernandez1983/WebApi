using AutoMapper;
using Backend.Entities.Facturacion;
using RestTest.Controllers.v1;

namespace Backend.Common.AutoMapperCustomConfiguration
{


    public class AutoMapperCustom: IAutoMapperCustom
    {


        public void InicilizarMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Factura, VMFactura>();
            });

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<Factura, VMFactura>();
            });

            IMapper mapper = config.CreateMapper();
        }
    }
}