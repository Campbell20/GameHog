namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Hardwares",
                c => new
                    {
                        HardwareId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.HardwareId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(),
                        LocationName = c.String(),
                        PhysicalStreetNumber = c.Int(nullable: false),
                        PhysicalStreetName = c.String(),
                        PhysicalStreetIdentifier = c.Int(nullable: false),
                        PhysicalStreetSecondaryIdentifier = c.Int(nullable: false),
                        PhysicalCity = c.String(),
                        PhysicalState = c.String(),
                        PhysicalZipCode = c.Int(nullable: false),
                        StoreHours = c.DateTime(nullable: false),
                        IsHomeStore = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stores");
            DropTable("dbo.Hardwares");
            DropTable("dbo.Games");
        }
    }
}
