using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class Tour_CitiesMap : EntityTypeConfiguration<Tour_Cities>
    {
        public Tour_CitiesMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(35);

            this.Property(t => t.NameRus)
                .IsRequired()
                .HasMaxLength(35);

            this.Property(t => t.FederalSubject)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tour_Cities");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NameRus).HasColumnName("NameRus");
            this.Property(t => t.FederalSubject).HasColumnName("FederalSubject");
        }
    }
}
