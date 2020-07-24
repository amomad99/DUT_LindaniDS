namespace lindaniDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleHires", "condition", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleHires", "cost", a => a.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleHires", "condition", c => c.String(nullable: false));
            AlterColumn("dbo.VehicleHires", "cost", a => a.Decimal(nullable: false));
        }
    }
}
