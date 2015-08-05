using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.country_code)
                .HasMaxLength(3);

            this.Property(t => t.country_name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Countries");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.country_code).HasColumnName("country_code");
            this.Property(t => t.country_name).HasColumnName("country_name");
        }
    }
}
