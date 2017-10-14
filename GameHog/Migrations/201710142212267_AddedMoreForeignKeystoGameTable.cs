namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreForeignKeystoGameTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "HardwaresId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "PublishersId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "DevelopersId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GenresId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "HardwaresId");
            CreateIndex("dbo.Games", "PublishersId");
            CreateIndex("dbo.Games", "DevelopersId");
            CreateIndex("dbo.Games", "GenresId");
            AddForeignKey("dbo.Games", "DevelopersId", "dbo.Developers", "DeveloperId", cascadeDelete: true);
            AddForeignKey("dbo.Games", "GenresId", "dbo.Genres", "GenreId", cascadeDelete: true);
            AddForeignKey("dbo.Games", "HardwaresId", "dbo.Hardwares", "HardwareId", cascadeDelete: true);
            AddForeignKey("dbo.Games", "PublishersId", "dbo.Publishers", "PublisherId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PublishersId", "dbo.Publishers");
            DropForeignKey("dbo.Games", "HardwaresId", "dbo.Hardwares");
            DropForeignKey("dbo.Games", "GenresId", "dbo.Genres");
            DropForeignKey("dbo.Games", "DevelopersId", "dbo.Developers");
            DropIndex("dbo.Games", new[] { "GenresId" });
            DropIndex("dbo.Games", new[] { "DevelopersId" });
            DropIndex("dbo.Games", new[] { "PublishersId" });
            DropIndex("dbo.Games", new[] { "HardwaresId" });
            DropColumn("dbo.Games", "GenresId");
            DropColumn("dbo.Games", "DevelopersId");
            DropColumn("dbo.Games", "PublishersId");
            DropColumn("dbo.Games", "HardwaresId");
        }
    }
}
