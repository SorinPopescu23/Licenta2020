namespace Licenta1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pozes",
                c => new
                    {
                        PozeId = c.Int(nullable: false),
                        Poza1 = c.String(),
                        Poza2 = c.String(),
                        Poza3 = c.String(),
                        Poza4 = c.String(),
                    })
                .PrimaryKey(t => t.PozeId)
                .ForeignKey("dbo.Eveniments", t => t.PozeId)
                .Index(t => t.PozeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pozes", "PozeId", "dbo.Eveniments");
            DropIndex("dbo.Pozes", new[] { "PozeId" });
            DropTable("dbo.Pozes");
        }
    }
}
