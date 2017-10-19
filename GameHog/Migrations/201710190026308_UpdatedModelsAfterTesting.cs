namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModelsAfterTesting : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accessories", "AccessoryUPCCode");
            DropColumn("dbo.Games", "GameUPCCode");
            DropColumn("dbo.Hardwares", "HardwareUPCCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hardwares", "HardwareUPCCode", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GameUPCCode", c => c.Int(nullable: false));
            AddColumn("dbo.Accessories", "AccessoryUPCCode", c => c.Int(nullable: false));
        }
    }
}
