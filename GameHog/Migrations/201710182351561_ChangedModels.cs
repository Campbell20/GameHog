namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accessories", "DeveloperId", "dbo.Developers");
            DropForeignKey("dbo.Accessories", "HardwareId", "dbo.Hardwares");
            DropForeignKey("dbo.Accessories", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.GameReviews", "AccesoryId", "dbo.Accessories");
            DropForeignKey("dbo.Games", "DevelopersId", "dbo.Developers");
            DropForeignKey("dbo.Games", "PublishersId", "dbo.Publishers");
            DropForeignKey("dbo.GameReviews", "GamesId", "dbo.Games");
            DropForeignKey("dbo.Games", "HardwaresId", "dbo.Hardwares");
            DropIndex("dbo.Accessories", new[] { "HardwareId" });
            DropIndex("dbo.Accessories", new[] { "PublisherId" });
            DropIndex("dbo.Accessories", new[] { "DeveloperId" });
            DropIndex("dbo.GameReviews", new[] { "GamesId" });
            DropIndex("dbo.GameReviews", new[] { "AccesoryId" });
            DropIndex("dbo.Games", new[] { "PublishersId" });
            DropIndex("dbo.Games", new[] { "DevelopersId" });
            DropPrimaryKey("dbo.Hardwares");
            AddColumn("dbo.Hardwares", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Hardwares", "HardwareAvailability", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hardwares", "HardwareAvailabilityCount", c => c.Int(nullable: false));
            AddColumn("dbo.Hardwares", "HardwareESRBRating", c => c.Int(nullable: false));
            AddColumn("dbo.Hardwares", "DeveloperName", c => c.String());
            AddColumn("dbo.Hardwares", "PublisherName", c => c.String());
            AddColumn("dbo.Games", "DeveloperName", c => c.String());
            AddColumn("dbo.Games", "PublisherName", c => c.String());
            AlterColumn("dbo.Hardwares", "HardwareId", c => c.Int(nullable: false));
            AlterColumn("dbo.Hardwares", "HardwareName", c => c.String());
            AlterColumn("dbo.Hardwares", "HardwareDescription", c => c.String());
            AlterColumn("dbo.Games", "GameName", c => c.String());
            AlterColumn("dbo.Games", "GameDescription", c => c.String());
            AlterColumn("dbo.Genres", "GenreName", c => c.String());
            AlterColumn("dbo.Genres", "GenreDescription", c => c.String());
            AlterColumn("dbo.Stores", "StoreName", c => c.String());
            AlterColumn("dbo.Stores", "LocationName", c => c.String());
            AlterColumn("dbo.Stores", "StorePhysicalStreet", c => c.String());
            AlterColumn("dbo.Stores", "StorePhysicalCity", c => c.String());
            AlterColumn("dbo.Stores", "StorePhysicalState", c => c.String());
            AlterColumn("dbo.Stores", "StorePhysicalZipCode", c => c.String());
            AlterColumn("dbo.Stores", "StoreHours", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Hardwares", "Id");
            CreateIndex("dbo.Hardwares", "Id");
            AddForeignKey("dbo.Hardwares", "Id", "dbo.Stores", "StoreId");
            AddForeignKey("dbo.Games", "HardwaresId", "dbo.Hardwares", "Id", cascadeDelete: true);
            DropColumn("dbo.Hardwares", "AccessoryPrice");
            DropColumn("dbo.Games", "GamePrice");
            DropColumn("dbo.Games", "PublishersId");
            DropColumn("dbo.Games", "DevelopersId");
            DropTable("dbo.Accessories");
            DropTable("dbo.Developers");
            DropTable("dbo.Publishers");
            DropTable("dbo.GameReviews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GameReviews",
                c => new
                    {
                        GameReviewId = c.Int(nullable: false, identity: true),
                        GameReviewName = c.String(maxLength: 50),
                        GameReviewDescription = c.String(maxLength: 500),
                        GameReviewStarValue = c.Int(nullable: false),
                        GamesId = c.Int(nullable: false),
                        AccesoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameReviewId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(nullable: false, maxLength: 25),
                        PublisherWebsite = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        DeveloperName = c.String(nullable: false, maxLength: 25),
                        DeveloperWebsite = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                        AccessoryName = c.String(nullable: false, maxLength: 50),
                        AccesoryDescription = c.String(nullable: false, maxLength: 500),
                        AccessoryPrice = c.Single(nullable: false),
                        AccesoryUPC = c.String(),
                        HardwareId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        DeveloperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessoryId);
            
            AddColumn("dbo.Games", "DevelopersId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "PublishersId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GamePrice", c => c.Single(nullable: false));
            AddColumn("dbo.Hardwares", "AccessoryPrice", c => c.Single(nullable: false));
            DropForeignKey("dbo.Games", "HardwaresId", "dbo.Hardwares");
            DropForeignKey("dbo.Hardwares", "Id", "dbo.Stores");
            DropIndex("dbo.Hardwares", new[] { "Id" });
            DropPrimaryKey("dbo.Hardwares");
            AlterColumn("dbo.Stores", "StoreHours", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Stores", "StorePhysicalZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "StorePhysicalState", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stores", "StorePhysicalCity", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stores", "StorePhysicalStreet", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stores", "LocationName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Stores", "StoreName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Genres", "GenreDescription", c => c.String(maxLength: 255));
            AlterColumn("dbo.Genres", "GenreName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Games", "GameDescription", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Games", "GameName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Hardwares", "HardwareDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Hardwares", "HardwareName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Hardwares", "HardwareId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Games", "PublisherName");
            DropColumn("dbo.Games", "DeveloperName");
            DropColumn("dbo.Hardwares", "PublisherName");
            DropColumn("dbo.Hardwares", "DeveloperName");
            DropColumn("dbo.Hardwares", "HardwareESRBRating");
            DropColumn("dbo.Hardwares", "HardwareAvailabilityCount");
            DropColumn("dbo.Hardwares", "HardwareAvailability");
            DropColumn("dbo.Hardwares", "Id");
            AddPrimaryKey("dbo.Hardwares", "HardwareId");
            CreateIndex("dbo.Games", "DevelopersId");
            CreateIndex("dbo.Games", "PublishersId");
            CreateIndex("dbo.GameReviews", "AccesoryId");
            CreateIndex("dbo.GameReviews", "GamesId");
            CreateIndex("dbo.Accessories", "DeveloperId");
            CreateIndex("dbo.Accessories", "PublisherId");
            CreateIndex("dbo.Accessories", "HardwareId");
            AddForeignKey("dbo.Games", "HardwaresId", "dbo.Hardwares", "HardwareId", cascadeDelete: true);
            AddForeignKey("dbo.GameReviews", "GamesId", "dbo.Games", "GameId", cascadeDelete: true);
            AddForeignKey("dbo.Games", "PublishersId", "dbo.Publishers", "PublisherId", cascadeDelete: true);
            AddForeignKey("dbo.Games", "DevelopersId", "dbo.Developers", "DeveloperId", cascadeDelete: true);
            AddForeignKey("dbo.GameReviews", "AccesoryId", "dbo.Accessories", "AccessoryId", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "PublisherId", "dbo.Publishers", "PublisherId", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "HardwareId", "dbo.Hardwares", "HardwareId", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "DeveloperId", "dbo.Developers", "DeveloperId", cascadeDelete: true);
        }
    }
}
