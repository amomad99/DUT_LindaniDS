namespace lindaniDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleHire : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleHires", "cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleHires", "cost", c => c.Double(nullable: false));
        }
    }
}
