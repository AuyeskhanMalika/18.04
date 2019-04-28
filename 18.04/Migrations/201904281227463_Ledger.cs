namespace _18._04.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ledger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ledgers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EnterTime = c.DateTime(nullable: false),
                        ExitTime = c.DateTime(),
                        PersonId = c.Guid(nullable: false),
                        VisitPurpose = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CertificateNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ledgers", "PersonId", "dbo.People");
            DropIndex("dbo.Ledgers", new[] { "PersonId" });
            DropTable("dbo.People");
            DropTable("dbo.Ledgers");
        }
    }
}
