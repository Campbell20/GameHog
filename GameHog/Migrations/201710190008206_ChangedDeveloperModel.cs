namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDeveloperModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                        AccessoryName = c.String(),
                        AccessoryDescription = c.String(),
                        AccessoryAvailability = c.Boolean(nullable: false),
                        AccessoryAvailabilityCount = c.Int(nullable: false),
                        AccessoryShippingUSAOnly = c.Boolean(nullable: false),
                        AccessoryUPCCode = c.Int(nullable: false),
                        DeveloperName = c.String(),
                        PublisherName = c.String(),
                    })
                .PrimaryKey(t => t.AccessoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accessories");
        }
    }
}
