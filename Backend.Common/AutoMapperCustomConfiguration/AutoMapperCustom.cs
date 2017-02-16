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
                cfg.CreateMap<LineaFactura, VMLineaFactura>();
                cfg.CreateMap<Presupuesto, VMPresupuesto>();
                cfg.CreateMap<LineaPresupuesto, VMLineaPresupuesto>();
                cfg.CreateMap<Pedido, VMPedido>();
                cfg.CreateMap<LineaPedido, VMLineaPedido>();
            });

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<Factura, VMFactura>();
                cfg.CreateMap<LineaFactura, VMLineaFactura>();
                cfg.CreateMap<Presupuesto, VMPresupuesto>();
                cfg.CreateMap<LineaPresupuesto, VMLineaPresupuesto>();
                cfg.CreateMap<Pedido, VMPedido>();
                cfg.CreateMap<LineaPedido, VMLineaPedido>();
            });

            IMapper mapper = config.CreateMapper();
        }
    }
}