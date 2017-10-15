namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMostDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Developers", "DeveloperName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Games", "GameName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Games", "GameDescription", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Genres", "GenreName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Hardwares", "HardwareName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Hardwares", "HardwareDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Publishers", "PublisherName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Stores", "StoreName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Stores", "LocationName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Stores", "StorePhysicalStreet", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stores", "StorePhysicalCity", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stores", "StorePhysicalState", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stores", "StorePhysicalZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "StoreHours", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "StoreHours", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Stores", "StorePhysicalZipCode", c => c.String());
            AlterColumn("dbo.Stores", "StorePhysicalState", c => c.String());
            AlterColumn("dbo.Stores", "StorePhysicalCity", c => c.String());
            AlterColumn("dbo.Stores", "StorePhysicalStreet", c => c.String());
            AlterColumn("dbo.Stores", "LocationName", c => c.String());
            AlterColumn("dbo.Stores", "StoreName", c => c.String());
            AlterColumn("dbo.Publishers", "PublisherName", c => c.String());
            AlterColumn("dbo.Hardwares", "HardwareDescription", c => c.String());
            AlterColumn("dbo.Hardwares", "HardwareName", c => c.String());
            AlterColumn("dbo.Genres", "GenreName", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "GameDescription", c => c.String());
            AlterColumn("dbo.Games", "GameName", c => c.String());
            AlterColumn("dbo.Developers", "DeveloperName", c => c.String(nullable: false));
        }
    }
}
