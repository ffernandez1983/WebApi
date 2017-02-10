﻿using Backend.Entities.DatosCliente;
using Backend.Entities.Facturacion;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Backend.Context
{
    public interface IUnitOfWork
    {
        IDbSet<Cliente> Clientes { get; set; }
        IDbSet<Proveedor> Proveedores { get; set; }

        IDbSet<Factura> Facturas { get; set; }
        IDbSet<LineaFactura> LineasFactura { get; set; }

        IDbSet<Presupuesto> Presupuestos { get; set; }
        IDbSet<LineaPresupuesto> LineasPresupuesto { get; set; }

        IDbSet<Pedido> Pedidos { get; set; }
        IDbSet<LineaPedido> LineasPedido { get; set; }

        IDbSet<Albaran> Albaranes { get; set; }
        IDbSet<LineaAlbaran> LineasAlbaran { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}