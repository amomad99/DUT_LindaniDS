namespace lindaniDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingPackages",
                c => new
                    {
                        packageID = c.Int(nullable: false, identity: true),
                        packageName = c.String(nullable: false),
                        cost = c.String(nullable: false),
                        availabilityDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.packageID);
            
            CreateTable(
                "dbo.VehicleHires",
                c => new
                    {
                        vehicleID = c.Int(nullable: false, identity: true),
                        modelID = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        color = c.String(nullable: false),
                        regNo = c.String(nullable: false),
                        noPlate = c.String(nullable: false),
                        cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        condition = c.String(nullable: false),
                        availability = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.vehicleID)
                .ForeignKey("dbo.VehicleModels", t => t.modelID, cascadeDelete: true)
                .Index(t => t.modelID);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        modelID = c.Int(nullable: false, identity: true),
                        vehicleName = c.String(nullable: false),
                        vehicleMake = c.String(nullable: false),
                        vehicleBodyType = c.String(nullable: false),
                        modelName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.modelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleHires", "modelID", "dbo.VehicleModels");
            DropIndex("dbo.VehicleHires", new[] { "modelID" });
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleHires");
            DropTable("dbo.BookingPackages");
        }
    }
}
