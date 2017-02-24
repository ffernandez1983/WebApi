namespace Backend.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albaran",
                c => new
                    {
                        IDAlbaran = c.Int(nullable: false),
                        NumeroAlbaran = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Factura_IDFactura = c.Int(),
                        Pedido_IDPedido = c.Int(),
                    })
                .PrimaryKey(t => t.IDAlbaran)
                .ForeignKey("dbo.Facturas", t => t.Factura_IDFactura)
                .ForeignKey("dbo.Pedidos", t => t.Pedido_IDPedido)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.Facturas", t => t.IDAlbaran)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .Index(t => t.IDAlbaran)
                .Index(t => t.ClienteId)
                .Index(t => t.ProveedorId)
                .Index(t => t.EmpresaId)
                .Index(t => t.Factura_IDFactura)
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
                        IDFactura = c.Int(nullable: false),
                        NumeroFactura = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Albaran_IDAlbaran = c.Int(),
                    })
                .PrimaryKey(t => t.IDFactura)
                .ForeignKey("dbo.Albaran", t => t.IDFactura)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Albaran", t => t.Albaran_IDAlbaran)
                .Index(t => t.IDFactura)
                .Index(t => t.ClienteId)
                .Index(t => t.ProveedorId)
                .Index(t => t.EmpresaId)
                .Index(t => t.Albaran_IDAlbaran);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        IDEmpresa = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        CIF = c.String(),
                        RazonSocial = c.String(),
                        Direccion = c.String(),
                        Pais = c.String(),
                        CodigoPostal = c.String(),
                        FormaJuridica = c.String(),
                        Nombre = c.String(),
                        Apellido1 = c.String(),
                        Apellido2 = c.String(),
                        DNI = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEmpresa)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        IDPedido = c.Int(nullable: false),
                        NumeroPedido = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Presupuesto_IDPresupuesto = c.Int(),
                    })
                .PrimaryKey(t => t.IDPedido)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.Presupuestos", t => t.Presupuesto_IDPresupuesto)
                .ForeignKey("dbo.Presupuestos", t => t.IDPedido)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .Index(t => t.IDPedido)
                .Index(t => t.ClienteId)
                .Index(t => t.ProveedorId)
                .Index(t => t.EmpresaId)
                .Index(t => t.Presupuesto_IDPresupuesto);
            
            CreateTable(
                "dbo.LineaPedido",
                c => new
                    {
                        IDLineaPedido = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        NumeroPedido = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDLineaPedido)
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        IDProducto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Precio = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IDProducto);
            
            CreateTable(
                "dbo.LineaAlbaran",
                c => new
                    {
                        IDLineaAlbaran = c.Int(nullable: false, identity: true),
                        AlbaranId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        NumeroAlbaran = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDLineaAlbaran)
                .ForeignKey("dbo.Albaran", t => t.AlbaranId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.AlbaranId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.LineaPresupuesto",
                c => new
                    {
                        IDLineaPresupuesto = c.Int(nullable: false, identity: true),
                        PresupuestoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        NumeroPresupuesto = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDLineaPresupuesto)
                .ForeignKey("dbo.Presupuestos", t => t.PresupuestoId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.PresupuestoId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Presupuestos",
                c => new
                    {
                        IDPresupuesto = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        NumeroPresupuesto = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        ImporteSubtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Impuesto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pedido_IDPedido = c.Int(),
                        Albaran_IDAlbaran = c.Int(),
                    })
                .PrimaryKey(t => t.IDPresupuesto)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.Pedidos", t => t.IDPresupuesto)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Pedidos", t => t.Pedido_IDPedido)
                .ForeignKey("dbo.Albaran", t => t.Albaran_IDAlbaran)
                .Index(t => t.IDPresupuesto)
                .Index(t => t.ClienteId)
                .Index(t => t.ProveedorId)
                .Index(t => t.EmpresaId)
                .Index(t => t.Pedido_IDPedido)
                .Index(t => t.Albaran_IDAlbaran);
            
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
                "dbo.Usuarios",
                c => new
                    {
                        IDUsuario = c.Int(nullable: false, identity: true),
                        DNI = c.String(),
                        Nombre = c.String(),
                        Apellido1 = c.String(),
                        Apellido2 = c.String(),
                        Direccion = c.String(),
                        Pais = c.String(),
                        CodigoPostal = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDUsuario);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albaran", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Presupuestos", "Albaran_IDAlbaran", "dbo.Albaran");
            DropForeignKey("dbo.Facturas", "Albaran_IDAlbaran", "dbo.Albaran");
            DropForeignKey("dbo.Albaran", "IDAlbaran", "dbo.Facturas");
            DropForeignKey("dbo.Albaran", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Albaran", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.LineaFactura", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Empresas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Pedidos", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Presupuestos", "Pedido_IDPedido", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "IDPedido", "dbo.Presupuestos");
            DropForeignKey("dbo.LineaPedido", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.LineaPresupuesto", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.LineaPresupuesto", "PresupuestoId", "dbo.Presupuestos");
            DropForeignKey("dbo.Presupuestos", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.Pedidos", "Presupuesto_IDPresupuesto", "dbo.Presupuestos");
            DropForeignKey("dbo.Presupuestos", "IDPresupuesto", "dbo.Pedidos");
            DropForeignKey("dbo.Presupuestos", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Presupuestos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.LineaAlbaran", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.LineaAlbaran", "AlbaranId", "dbo.Albaran");
            DropForeignKey("dbo.LineaPedido", "PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Pedidos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Albaran", "Pedido_IDPedido", "dbo.Pedidos");
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Albaran", "Factura_IDFactura", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "IDFactura", "dbo.Albaran");
            DropIndex("dbo.LineaFactura", new[] { "FacturaId" });
            DropIndex("dbo.Presupuestos", new[] { "Albaran_IDAlbaran" });
            DropIndex("dbo.Presupuestos", new[] { "Pedido_IDPedido" });
            DropIndex("dbo.Presupuestos", new[] { "EmpresaId" });
            DropIndex("dbo.Presupuestos", new[] { "ProveedorId" });
            DropIndex("dbo.Presupuestos", new[] { "ClienteId" });
            DropIndex("dbo.Presupuestos", new[] { "IDPresupuesto" });
            DropIndex("dbo.LineaPresupuesto", new[] { "ProductoId" });
            DropIndex("dbo.LineaPresupuesto", new[] { "PresupuestoId" });
            DropIndex("dbo.LineaAlbaran", new[] { "ProductoId" });
            DropIndex("dbo.LineaAlbaran", new[] { "AlbaranId" });
            DropIndex("dbo.LineaPedido", new[] { "ProductoId" });
            DropIndex("dbo.LineaPedido", new[] { "PedidoId" });
            DropIndex("dbo.Pedidos", new[] { "Presupuesto_IDPresupuesto" });
            DropIndex("dbo.Pedidos", new[] { "EmpresaId" });
            DropIndex("dbo.Pedidos", new[] { "ProveedorId" });
            DropIndex("dbo.Pedidos", new[] { "ClienteId" });
            DropIndex("dbo.Pedidos", new[] { "IDPedido" });
            DropIndex("dbo.Empresas", new[] { "UsuarioId" });
            DropIndex("dbo.Facturas", new[] { "Albaran_IDAlbaran" });
            DropIndex("dbo.Facturas", new[] { "EmpresaId" });
            DropIndex("dbo.Facturas", new[] { "ProveedorId" });
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            DropIndex("dbo.Facturas", new[] { "IDFactura" });
            DropIndex("dbo.Albaran", new[] { "Pedido_IDPedido" });
            DropIndex("dbo.Albaran", new[] { "Factura_IDFactura" });
            DropIndex("dbo.Albaran", new[] { "EmpresaId" });
            DropIndex("dbo.Albaran", new[] { "ProveedorId" });
            DropIndex("dbo.Albaran", new[] { "ClienteId" });
            DropIndex("dbo.Albaran", new[] { "IDAlbaran" });
            DropTable("dbo.LineaFactura");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Presupuestos");
            DropTable("dbo.LineaPresupuesto");
            DropTable("dbo.LineaAlbaran");
            DropTable("dbo.Productoes");
            DropTable("dbo.LineaPedido");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Empresas");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Albaran");
        }
    }
}
