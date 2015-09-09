using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EvolutionService.Models.Mapping;

namespace EvolutionService.Models
{
    public partial class EvolutionServiceContext : DbContext
    {
        static EvolutionServiceContext()
        {
            Database.SetInitializer<EvolutionServiceContext>(null);
        }

        public EvolutionServiceContext()
            : base("Name=EvolutionServiceContext")
        {
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ModelMap());
            modelBuilder.Configurations.Add(new UnitMap());
        }
    }
}
