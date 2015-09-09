namespace EvolutionService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Guid(nullable: false),
                        UnitId = c.Guid(nullable: false),
                        FileName = c.String(),
                        Data = c.String(),
                        Context = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        Result = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UnitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "UnitId", "dbo.Units");
            DropIndex("dbo.Models", new[] { "UnitId" });
            DropTable("dbo.Units");
            DropTable("dbo.Models");
        }
    }
}
