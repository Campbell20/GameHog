namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                        AccessoryName = c.String(nullable: false, maxLength: 50),
                        AccesoryDescription = c.String(nullable: false, maxLength: 500),
                        HardwareId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessoryId)
                .ForeignKey("dbo.Hardwares", t => t.HardwareId, cascadeDelete: true)
                .Index(t => t.HardwareId);
            
            CreateTable(
                "dbo.GameReviews",
                c => new
                    {
                        GameReviewId = c.Int(nullable: false, identity: true),
                        GameReviewName = c.String(maxLength: 50),
                        GameReviewDescription = c.String(maxLength: 500),
                        GameReviewStarValue = c.Int(nullable: false),
                        GamesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameReviewId)
                .ForeignKey("dbo.Games", t => t.GamesId, cascadeDelete: true)
                .Index(t => t.GamesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameReviews", "GamesId", "dbo.Games");
            DropForeignKey("dbo.Accessories", "HardwareId", "dbo.Hardwares");
            DropIndex("dbo.GameReviews", new[] { "GamesId" });
            DropIndex("dbo.Accessories", new[] { "HardwareId" });
            DropTable("dbo.GameReviews");
            DropTable("dbo.Accessories");
        }
    }
}
