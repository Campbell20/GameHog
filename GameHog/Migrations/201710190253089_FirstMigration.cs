namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccessoryName = c.String(),
                        AccessoryDescription = c.String(),
                        AccessoryAvailability = c.Boolean(nullable: false),
                        AccessoryAvailabilityCount = c.Int(nullable: false),
                        AccessoryShippingUSAOnly = c.Boolean(nullable: false),
                        DeveloperName = c.String(),
                        PublisherName = c.String(),
                        StoreId = c.Int(nullable: false),
                        HardwareId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hardwares", t => t.HardwareId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.HardwareId);
            
            CreateTable(
                "dbo.Hardwares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HardwareName = c.String(),
                        HardwareDescription = c.String(),
                        HardwareAvailability = c.Boolean(nullable: false),
                        HardwareAvailabilityCount = c.Int(nullable: false),
                        HardwareShippingUSAOnly = c.Boolean(nullable: false),
                        DeveloperName = c.String(),
                        PublisherName = c.String(),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: false)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreName = c.String(),
                        LocationName = c.String(),
                        StorePhysicalStreet = c.String(),
                        StorePhysicalCity = c.String(),
                        StorePhysicalState = c.String(),
                        StorePhysicalZipCode = c.String(),
                        StoreHours = c.String(),
                        IsHomeStore = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameName = c.String(),
                        GameDescription = c.String(),
                        GameAvailability = c.Boolean(nullable: false),
                        GameAvailabilityCount = c.Int(nullable: false),
                        GameShippingUSAOnly = c.Boolean(nullable: false),
                        GameESRBRating = c.Int(nullable: false),
                        DeveloperName = c.String(),
                        PublisherName = c.String(),
                        StoreId = c.Int(nullable: false),
                        HardwareId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Hardwares", t => t.HardwareId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.HardwareId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        GenreDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Games", "HardwareId", "dbo.Hardwares");
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Accessories", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Accessories", "HardwareId", "dbo.Hardwares");
            DropForeignKey("dbo.Hardwares", "StoreId", "dbo.Stores");
            DropIndex("dbo.Games", new[] { "GenreId" });
            DropIndex("dbo.Games", new[] { "HardwareId" });
            DropIndex("dbo.Games", new[] { "StoreId" });
            DropIndex("dbo.Hardwares", new[] { "StoreId" });
            DropIndex("dbo.Accessories", new[] { "HardwareId" });
            DropIndex("dbo.Accessories", new[] { "StoreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Games");
            DropTable("dbo.Stores");
            DropTable("dbo.Hardwares");
            DropTable("dbo.Accessories");
        }
    }
}
