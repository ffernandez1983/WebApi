namespace Backend.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albaran",
                c => new
                    {
                        IDAlbaran = c.Int(nullable: false, identity: true),
                        NumeroAlbaran = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pedido_IDPedido = c.Int(),
                    })
                .PrimaryKey(t => t.IDAlbaran)
                .ForeignKey("dbo.Pedidos", t => t.Pedido_IDPedido)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.ProveedorId)
                .Index(t => t.Pedido_IDPedido);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IDCliente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido1 = c.String(),
                        Apellido2 = c.String(),
                    })
                .PrimaryKey(t => t.IDCliente);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        IDFactura = c.Int(nullable: false, identity: true),
                        NumeroFactura = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDFactura)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.LineaFactura",
                c => new
                    {
                        IDLineaFactura = c.Int(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        NumeroFactura = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDLineaFactura)
                .ForeignKey("dbo.Facturas", t => t.FacturaId, cascadeDelete: true)
                .Index(t => t.FacturaId);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        IDProveedor = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido1 = c.String(),
                        Apellido2 = c.String(),
                    })
                .PrimaryKey(t => t.IDProveedor);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        IDPedido = c.Int(nullable: false, identity: true),
                        NumeroPedido = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDPedido)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.LineaPedido",
                c => new
                    {
                        IDLineaPedido = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        NumeroPedido = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDLineaPedido)
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Presupuestos",
                c => new
                    {
                        IDPresupuesto = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        NumeroPresupuesto = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Albaran_IDAlbaran = c.Int(),
                    })
                .PrimaryKey(t => t.IDPresupuesto)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Albaran", t => t.Albaran_IDAlbaran)
                .Index(t => t.ClienteId)
                .Index(t => t.ProveedorId)
                .Index(t => t.Albaran_IDAlbaran);
            
            CreateTable(
                "dbo.LineaPresupuesto",
                c => new
                    {
                        IDLineaPresupuesto = c.Int(nullable: false, identity: true),
                        PresupuestoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        NumeroPresupuesto = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDLineaPresupuesto)
                .ForeignKey("dbo.Presupuestos", t => t.PresupuestoId, cascadeDelete: true)
                .Index(t => t.PresupuestoId);
            
            CreateTable(
                "dbo.LineaAlbaran",
                c => new
                    {
                        IDLineaAlbaran = c.Int(nullable: false, identity: true),
                        AlbaranId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        NumeroAlbaran = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDLineaAlbaran)
                .ForeignKey("dbo.Albaran", t => t.AlbaranId, cascadeDelete: true)
                .Index(t => t.AlbaranId);
            
            CreateTable(
                "dbo.FacturaAlbarans",
                c => new
                    {
                        Factura_IDFactura = c.Int(nullable: false),
                        Albaran_IDAlbaran = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Factura_IDFactura, t.Albaran_IDAlbaran })
                
                .Index(t => t.Factura_IDFactura)
                .Index(t => t.Albaran_IDAlbaran);
            
            CreateTable(
                "dbo.PresupuestoPedidoes",
                c => new
                    {
                        Presupuesto_IDPresupuesto = c.Int(nullable: false),
                        Pedido_IDPedido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Presupuesto_IDPresupuesto, t.Pedido_IDPedido })
               
                .Index(t => t.Presupuesto_IDPresupuesto)
                .Index(t => t.Pedido_IDPedido);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albaran", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Presupuestos", "Albaran_IDAlbaran", "dbo.Albaran");
            DropForeignKey("dbo.LineaAlbaran", "AlbaranId", "dbo.Albaran");
            DropForeignKey("dbo.Albaran", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Pedidos", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Presupuestos", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.PresupuestoPedidoes", "Pedido_IDPedido", "dbo.Pedidos");
            DropForeignKey("dbo.PresupuestoPedidoes", "Presupuesto_IDPresupuesto", "dbo.Presupuestos");
            DropForeignKey("dbo.LineaPresupuesto", "PresupuestoId", "dbo.Presupuestos");
            DropForeignKey("dbo.Presupuestos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.LineaPedido", "PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Albaran", "Pedido_IDPedido", "dbo.Pedidos");
            DropForeignKey("dbo.LineaFactura", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.FacturaAlbarans", "Albaran_IDAlbaran", "dbo.Albaran");
            DropForeignKey("dbo.FacturaAlbarans", "Factura_IDFactura", "dbo.Facturas");
            DropIndex("dbo.PresupuestoPedidoes", new[] { "Pedido_IDPedido" });
            DropIndex("dbo.PresupuestoPedidoes", new[] { "Presupuesto_IDPresupuesto" });
            DropIndex("dbo.FacturaAlbarans", new[] { "Albaran_IDAlbaran" });
            DropIndex("dbo.FacturaAlbarans", new[] { "Factura_IDFactura" });
            DropIndex("dbo.LineaAlbaran", new[] { "AlbaranId" });
            DropIndex("dbo.LineaPresupuesto", new[] { "PresupuestoId" });
            DropIndex("dbo.Presupuestos", new[] { "Albaran_IDAlbaran" });
            DropIndex("dbo.Presupuestos", new[] { "ProveedorId" });
            DropIndex("dbo.Presupuestos", new[] { "ClienteId" });
            DropIndex("dbo.LineaPedido", new[] { "PedidoId" });
            DropIndex("dbo.Pedidos", new[] { "ProveedorId" });
            DropIndex("dbo.Pedidos", new[] { "ClienteId" });
            DropIndex("dbo.LineaFactura", new[] { "FacturaId" });
            DropIndex("dbo.Facturas", new[] { "ProveedorId" });
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            DropIndex("dbo.Albaran", new[] { "Pedido_IDPedido" });
            DropIndex("dbo.Albaran", new[] { "ProveedorId" });
            DropIndex("dbo.Albaran", new[] { "ClienteId" });
            DropTable("dbo.PresupuestoPedidoes");
            DropTable("dbo.FacturaAlbarans");
            DropTable("dbo.LineaAlbaran");
            DropTable("dbo.LineaPresupuesto");
            DropTable("dbo.Presupuestos");
            DropTable("dbo.LineaPedido");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Proveedors");
            DropTable("dbo.LineaFactura");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Albaran");
        }
    }
}
