namespace Backend.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        IDProducto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Precio = c.String(),
                    })
                .PrimaryKey(t => t.IDProducto);
            
            AddColumn("dbo.LineaPedido", "ProductoId", c => c.Int(nullable: false));
            AddColumn("dbo.LineaPresupuesto", "ProductoId", c => c.Int(nullable: false));
            AddColumn("dbo.LineaAlbaran", "ProductoId", c => c.Int(nullable: false));
            CreateIndex("dbo.LineaPedido", "ProductoId");
            CreateIndex("dbo.LineaAlbaran", "ProductoId");
            CreateIndex("dbo.LineaPresupuesto", "ProductoId");
            AddForeignKey("dbo.LineaAlbaran", "ProductoId", "dbo.Productoes", "IDProducto", cascadeDelete: true);
            AddForeignKey("dbo.LineaPresupuesto", "ProductoId", "dbo.Productoes", "IDProducto", cascadeDelete: true);
            AddForeignKey("dbo.LineaPedido", "ProductoId", "dbo.Productoes", "IDProducto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineaPedido", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.LineaPresupuesto", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.LineaAlbaran", "ProductoId", "dbo.Productoes");
            DropIndex("dbo.LineaPresupuesto", new[] { "ProductoId" });
            DropIndex("dbo.LineaAlbaran", new[] { "ProductoId" });
            DropIndex("dbo.LineaPedido", new[] { "ProductoId" });
            DropColumn("dbo.LineaAlbaran", "ProductoId");
            DropColumn("dbo.LineaPresupuesto", "ProductoId");
            DropColumn("dbo.LineaPedido", "ProductoId");
            DropTable("dbo.Productoes");
        }
    }
}
