namespace lindaniDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleHires", "condition", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleHires", "condition", c => c.String(nullable: false));
        }
    }
}
