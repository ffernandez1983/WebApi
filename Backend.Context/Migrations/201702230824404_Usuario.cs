namespace Backend.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario : DbMigration
    {
        public override void Up()
        {            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IDUsuario = c.Int(nullable: false, identity: true),
                        DNI = c.String(),
                        Direccion = c.String(),
                        Pais = c.String(),
                        CodigoPostal = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDUsuario);
            
            AddColumn("dbo.Empresas", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empresas", "UsuarioId");
            //AddForeignKey("dbo.Empresas", "UsuarioId", "dbo.Usuarios", "IDUsuario", cascadeDelete: true);           
        }
        
        public override void Down()
        {
           
        }
    }
}
