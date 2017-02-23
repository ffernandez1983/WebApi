namespace Backend.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario2 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Empresas", "UsuarioId", "dbo.Usuarios", "IDUsuario", cascadeDelete: true);
        }
        
        public override void Down()
        {
        }
    }
}
