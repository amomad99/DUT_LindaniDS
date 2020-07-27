namespace lindaniDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleHire : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.VehicleHires", "Email", c => c.String(nullable: false, maxLength: 100));
           // DropColumn("dbo.VehicleHires", "Img");
        }
        
        public override void Down()
        {
          //  AddColumn("dbo.VehicleHires", "Img", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.VehicleHires", "Email");
        }
    }
}
