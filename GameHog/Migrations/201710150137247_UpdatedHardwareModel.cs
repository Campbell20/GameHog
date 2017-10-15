namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedHardwareModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "DeveloperWebsite", c => c.String(nullable: false));
            AddColumn("dbo.Publishers", "PublisherWebsite", c => c.String());
            AlterColumn("dbo.Developers", "DeveloperName", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "GenreName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "GenreName", c => c.String());
            AlterColumn("dbo.Developers", "DeveloperName", c => c.String());
            DropColumn("dbo.Publishers", "PublisherWebsite");
            DropColumn("dbo.Developers", "DeveloperWebsite");
        }
    }
}
