namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeystoGameTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "StoresId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "StoresId");
            AddForeignKey("dbo.Games", "StoresId", "dbo.Stores", "StoreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "StoresId", "dbo.Stores");
            DropIndex("dbo.Games", new[] { "StoresId" });
            DropColumn("dbo.Games", "StoresId");
        }
    }
}
