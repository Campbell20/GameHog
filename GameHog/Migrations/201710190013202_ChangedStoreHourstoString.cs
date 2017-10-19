namespace GameHog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStoreHourstoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stores", "StoreHours", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "StoreHours", c => c.DateTime(nullable: false));
        }
    }
}
