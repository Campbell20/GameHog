namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeytoGameReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameReviews", "AccesoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.GameReviews", "AccesoryId");
            AddForeignKey("dbo.GameReviews", "AccesoryId", "dbo.Accessories", "AccessoryId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameReviews", "AccesoryId", "dbo.Accessories");
            DropIndex("dbo.GameReviews", new[] { "AccesoryId" });
            DropColumn("dbo.GameReviews", "AccesoryId");
        }
    }
}
