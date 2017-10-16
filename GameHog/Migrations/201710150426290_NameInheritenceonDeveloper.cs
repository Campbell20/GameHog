namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameInheritenceonDeveloper : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NameDescriptions", "DeveloperId", c => c.Int());
            AddColumn("dbo.NameDescriptions", "DeveloperWebsite", c => c.String());
            AddColumn("dbo.NameDescriptions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            //DropTable("dbo.Developers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        DeveloperWebsite = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
            DropColumn("dbo.NameDescriptions", "Discriminator");
            DropColumn("dbo.NameDescriptions", "DeveloperWebsite");
            DropColumn("dbo.NameDescriptions", "DeveloperId");
        }
    }
}
