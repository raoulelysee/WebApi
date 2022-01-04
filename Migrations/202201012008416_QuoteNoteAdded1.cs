namespace QuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteNoteAdded1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Quotes", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quotes", "Note", c => c.String());
        }
    }
}
