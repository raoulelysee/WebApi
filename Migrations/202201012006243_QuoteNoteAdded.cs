namespace QuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteNoteAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "Note");
        }
    }
}
