using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EvolutionService.Models.Mapping
{
    public class ModelMap : EntityTypeConfiguration<Model>
    {
        public ModelMap()
        {
            // Primary Key
            this.HasKey(t => t.ModelId);

            // Properties
            this.Property(t => t.Context)
                .HasMaxLength(50);

            this.Property(t => t.ModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Models");
            this.Property(t => t.ModelId).HasColumnName("ModelId");
            this.Property(t => t.UnitId).HasColumnName("UnitId");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Context).HasColumnName("Context");

            // Relationships
            this.HasRequired(t => t.Unit)
                .WithMany(t => t.Models)
                .HasForeignKey(d => d.UnitId);

        }
    }
}
