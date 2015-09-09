namespace EvolutionService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertStrategyField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Units", "Strategy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Units", "Strategy");
        }
    }
}
