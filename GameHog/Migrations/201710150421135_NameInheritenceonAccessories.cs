namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameInheritenceonAccessories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NameDescriptions",
                c => new
                    {
                        NameDescriptionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(maxLength: 500),
                        AccessoryId = c.Int(),
                    })
                .PrimaryKey(t => t.NameDescriptionId);
            
            DropColumn("dbo.Developers", "DeveloperName");
            DropColumn("dbo.Games", "GameName");
            DropColumn("dbo.Games", "GameDescription");
            DropColumn("dbo.Genres", "GenreName");
            DropColumn("dbo.Genres", "GenreDescription");
            DropColumn("dbo.Hardwares", "HardwareName");
            DropColumn("dbo.Hardwares", "HardwareDescription");
            DropColumn("dbo.Publishers", "PublisherName");
            DropColumn("dbo.Stores", "StoreName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "StoreName", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Publishers", "PublisherName", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Hardwares", "HardwareDescription", c => c.String(maxLength: 500));
            AddColumn("dbo.Hardwares", "HardwareName", c => c.String(maxLength: 25));
            AddColumn("dbo.Genres", "GenreDescription", c => c.String(maxLength: 255));
            AddColumn("dbo.Genres", "GenreName", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Games", "GameDescription", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Games", "GameName", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Developers", "DeveloperName", c => c.String(nullable: false, maxLength: 25));
            DropTable("dbo.NameDescriptions");
        }
    }
}
