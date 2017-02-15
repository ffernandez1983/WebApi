namespace Backend.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Producto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "Precio", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "Precio", c => c.String());
        }
    }
}
