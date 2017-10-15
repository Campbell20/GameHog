namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGenresDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "GenreDescription", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "GenreDescription", c => c.String());
        }
    }
}
