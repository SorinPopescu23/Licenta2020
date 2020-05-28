namespace Licenta1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonats",
                c => new
                    {
                        AbonatId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EvenimentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AbonatId)
                .ForeignKey("dbo.Eveniments", t => t.EvenimentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EvenimentId);
            
            CreateTable(
                "dbo.Eveniments",
                c => new
                    {
                        EvenimentId = c.Int(nullable: false, identity: true),
                        NumeEvent = c.String(),
                        DataEvent = c.DateTime(nullable: false),
                        DescriereEvent = c.String(),
                        PozeEvent = c.String(),
                        GenEvent = c.String(),
                    })
                .PrimaryKey(t => t.EvenimentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Abonats", "UserId", "dbo.Users");
            DropForeignKey("dbo.Abonats", "EvenimentId", "dbo.Eveniments");
            DropIndex("dbo.Abonats", new[] { "EvenimentId" });
            DropIndex("dbo.Abonats", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Eveniments");
            DropTable("dbo.Abonats");
        }
    }
}
