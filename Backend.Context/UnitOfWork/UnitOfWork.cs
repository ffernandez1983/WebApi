using Backend.Entities.DatosCliente;
using Backend.Entities.DatosEmpresa;
using Backend.Entities.DatosProveedor;
using Backend.Entities.Facturacion;
using Backend.Entities.Productos;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Backend.Context
{
    public class UnitOfWork: DbContext, IUnitOfWork
    {
        public UnitOfWork()
            : base("name=UnitOfWork")
        {

        }
        public virtual IDbSet<Empresa> Empresas { get; set; }

        public virtual IDbSet<Cliente> Clientes { get; set; }
        public virtual IDbSet<Proveedor> Proveedores { get; set; }

        public virtual IDbSet<Producto> Productos { get; set; }

        public virtual IDbSet<Factura> Facturas { get; set; }
        public virtual IDbSet<LineaFactura> LineasFactura { get; set; }

        public virtual IDbSet<Presupuesto> Presupuestos { get; set; }
        public virtual IDbSet<LineaPresupuesto> LineasPresupuesto { get; set; }

        public virtual IDbSet<Pedido> Pedidos { get; set; }
        public virtual IDbSet<LineaPedido> LineasPedido { get; set; }

        public virtual IDbSet<Albaran> Albaranes { get; set; }
        public virtual IDbSet<LineaAlbaran> LineasAlbaran { get; set; }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();

        //}

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
   
}
