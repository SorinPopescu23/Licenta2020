namespace Licenta1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Name", c => c.String());
            DropColumn("dbo.Comments", "Nume");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Nume", c => c.String());
            DropColumn("dbo.Comments", "Name");
        }
    }
}
