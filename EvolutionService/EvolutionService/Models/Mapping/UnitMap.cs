using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EvolutionService.Models.Mapping
{
    public class UnitMap : EntityTypeConfiguration<Unit>
    {
        public UnitMap()
        {
            // Primary Key
            this.HasKey(t => t.UnitId);

            this.Property(t => t.UnitId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            // Table & Column Mappings
            this.ToTable("Units");
            this.Property(t => t.UnitId).HasColumnName("UnitId");
            this.Property(t => t.Strategy).HasColumnName("Strategy");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Result).HasColumnName("Result");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
