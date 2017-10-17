namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCurrency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accessories", "AccessoryPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Accessories", "AccesoryUPC", c => c.String());
            AddColumn("dbo.Accessories", "PublisherId", c => c.Int(nullable: false));
            AddColumn("dbo.Accessories", "DeveloperId", c => c.Int(nullable: false));
            AddColumn("dbo.Hardwares", "AccessoryPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Games", "GamePrice", c => c.Single(nullable: false));
            CreateIndex("dbo.Accessories", "PublisherId");
            CreateIndex("dbo.Accessories", "DeveloperId");
            AddForeignKey("dbo.Accessories", "DeveloperId", "dbo.Developers", "DeveloperId", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "PublisherId", "dbo.Publishers", "PublisherId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accessories", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Accessories", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.Accessories", new[] { "DeveloperId" });
            DropIndex("dbo.Accessories", new[] { "PublisherId" });
            DropColumn("dbo.Games", "GamePrice");
            DropColumn("dbo.Hardwares", "AccessoryPrice");
            DropColumn("dbo.Accessories", "DeveloperId");
            DropColumn("dbo.Accessories", "PublisherId");
            DropColumn("dbo.Accessories", "AccesoryUPC");
            DropColumn("dbo.Accessories", "AccessoryPrice");
        }
    }
}
