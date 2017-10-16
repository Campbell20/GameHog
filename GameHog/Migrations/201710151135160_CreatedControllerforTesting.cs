namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedControllerforTesting : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NameDescriptions", newName: "Accessories");
            DropForeignKey("dbo.Games", "DevelopersId", "dbo.NameDescriptions");
            DropPrimaryKey("dbo.Accessories");
            CreateTable(
                "dbo.NameDescriptions",
                c => new
                    {
                        NameDescriptionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(maxLength: 500),
                        DeveloperId = c.Int(),
                        DeveloperWebsite = c.String(),
                    })
                .PrimaryKey(t => t.NameDescriptionId);
            
            AlterColumn("dbo.Accessories", "AccessoryId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Accessories", "AccessoryId");
            DropColumn("dbo.Accessories", "NameDescriptionId");
            DropColumn("dbo.Accessories", "Name");
            DropColumn("dbo.Accessories", "Description");
            DropColumn("dbo.Accessories", "DeveloperId");
            DropColumn("dbo.Accessories", "DeveloperWebsite");
            DropColumn("dbo.Accessories", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accessories", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Accessories", "DeveloperWebsite", c => c.String());
            AddColumn("dbo.Accessories", "DeveloperId", c => c.Int());
            AddColumn("dbo.Accessories", "Description", c => c.String(maxLength: 500));
            AddColumn("dbo.Accessories", "Name", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Accessories", "NameDescriptionId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Accessories");
            AlterColumn("dbo.Accessories", "AccessoryId", c => c.Int());
            DropTable("dbo.NameDescriptions");
            AddPrimaryKey("dbo.Accessories", "NameDescriptionId");
            AddForeignKey("dbo.Games", "DevelopersId", "dbo.NameDescriptions", "NameDescriptionId", cascadeDelete: true);
            RenameTable(name: "dbo.Accessories", newName: "NameDescriptions");
        }
    }
}
