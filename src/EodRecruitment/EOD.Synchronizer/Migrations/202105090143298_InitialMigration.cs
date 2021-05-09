namespace EOD.Synchronizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kontrahenci",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 450),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 450),
                        Removed = c.Boolean(),
                        Archived = c.Boolean(),
                        Cancelled = c.Boolean(),
                        Rejected = c.Boolean(),
                        Zrodlo = c.String(),
                        IdentyfikatorZrodla = c.Guid(nullable: false),
                        NIP = c.String(maxLength: 10),
                        Nazwa = c.String(maxLength: 450),
                        Miasto = c.String(maxLength: 450),
                        KodPocztowy = c.String(maxLength: 450),
                        Ulica = c.String(maxLength: 450),
                        Numer = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kontrahenci");
        }
    }
}
