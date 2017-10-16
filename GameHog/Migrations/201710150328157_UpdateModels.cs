namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "ESRBRatingValue", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "GameESRBRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "GameESRBRating", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "ESRBRatingValue");
        }
    }
}
