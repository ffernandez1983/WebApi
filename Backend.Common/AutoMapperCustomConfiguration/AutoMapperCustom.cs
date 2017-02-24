using AutoMapper;
using Backend.Entities.DatosUsuario;
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
                cfg.CreateMap<Usuario, VMUsuario>();
                cfg.CreateMap<LineaFactura, VMLineaFactura>();
                cfg.CreateMap<Presupuesto, VMPresupuesto>();
                cfg.CreateMap<LineaPresupuesto, VMLineaPresupuesto>();
                cfg.CreateMap<Pedido, VMPedido>();            
                cfg.CreateMap<LineaPedido, VMLineaPedido>();
                cfg.CreateMap<Albaran, VMAlbaran>();
                cfg.CreateMap<LineaAlbaran, VMLineaAlbaran>();
            });

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<Factura, VMFactura>();
                cfg.CreateMap<Usuario, VMUsuario>();
                cfg.CreateMap<LineaFactura, VMLineaFactura>();
                cfg.CreateMap<Presupuesto, VMPresupuesto>();
                cfg.CreateMap<LineaPresupuesto, VMLineaPresupuesto>();
                cfg.CreateMap<Pedido, VMPedido>();
                cfg.CreateMap<LineaPedido, VMLineaPedido>();
                cfg.CreateMap<Albaran, VMAlbaran>();
                cfg.CreateMap<LineaAlbaran, VMLineaAlbaran>();
            });

            IMapper mapper = config.CreateMapper();
        }
    }
}