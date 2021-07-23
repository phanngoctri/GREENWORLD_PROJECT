namespace GreenStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "PostalCode");
            DropColumn("dbo.Orders", "Country");
            DropColumn("dbo.Orders", "Experation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Experation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Country", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "PostalCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Items", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
