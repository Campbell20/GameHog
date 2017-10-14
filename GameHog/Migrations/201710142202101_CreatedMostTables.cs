namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedMostTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        DeveloperName = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        GenreDescription = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
            AddColumn("dbo.Games", "GameName", c => c.String());
            AddColumn("dbo.Games", "GameDescription", c => c.String());
            AddColumn("dbo.Games", "GameAvailability", c => c.Boolean(nullable: false));
            AddColumn("dbo.Games", "GameAvailabilityCount", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GameShippingUSAOnly", c => c.Boolean(nullable: false));
            AddColumn("dbo.Games", "GameUPCCode", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GameESRBRating", c => c.Int(nullable: false));
            AddColumn("dbo.Hardwares", "HardwareName", c => c.String());
            AddColumn("dbo.Hardwares", "HardwareDescription", c => c.String());
            AddColumn("dbo.Hardwares", "HardwareShippingUSAOnly", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hardwares", "HardwareUPCCode", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "StorePhysicalStreet", c => c.String());
            AddColumn("dbo.Stores", "StorePhysicalCity", c => c.String());
            AddColumn("dbo.Stores", "StorePhysicalState", c => c.String());
            AddColumn("dbo.Stores", "StorePhysicalZipCode", c => c.String());
            DropColumn("dbo.Stores", "PhysicalStreetNumber");
            DropColumn("dbo.Stores", "PhysicalStreetName");
            DropColumn("dbo.Stores", "PhysicalStreetIdentifier");
            DropColumn("dbo.Stores", "PhysicalStreetSecondaryIdentifier");
            DropColumn("dbo.Stores", "PhysicalCity");
            DropColumn("dbo.Stores", "PhysicalState");
            DropColumn("dbo.Stores", "PhysicalZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "PhysicalZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "PhysicalState", c => c.String());
            AddColumn("dbo.Stores", "PhysicalCity", c => c.String());
            AddColumn("dbo.Stores", "PhysicalStreetSecondaryIdentifier", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "PhysicalStreetIdentifier", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "PhysicalStreetName", c => c.String());
            AddColumn("dbo.Stores", "PhysicalStreetNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Stores", "StorePhysicalZipCode");
            DropColumn("dbo.Stores", "StorePhysicalState");
            DropColumn("dbo.Stores", "StorePhysicalCity");
            DropColumn("dbo.Stores", "StorePhysicalStreet");
            DropColumn("dbo.Hardwares", "HardwareUPCCode");
            DropColumn("dbo.Hardwares", "HardwareShippingUSAOnly");
            DropColumn("dbo.Hardwares", "HardwareDescription");
            DropColumn("dbo.Hardwares", "HardwareName");
            DropColumn("dbo.Games", "GameESRBRating");
            DropColumn("dbo.Games", "GameUPCCode");
            DropColumn("dbo.Games", "GameShippingUSAOnly");
            DropColumn("dbo.Games", "GameAvailabilityCount");
            DropColumn("dbo.Games", "GameAvailability");
            DropColumn("dbo.Games", "GameDescription");
            DropColumn("dbo.Games", "GameName");
            DropTable("dbo.Publishers");
            DropTable("dbo.Genres");
            DropTable("dbo.Developers");
        }
    }
}
