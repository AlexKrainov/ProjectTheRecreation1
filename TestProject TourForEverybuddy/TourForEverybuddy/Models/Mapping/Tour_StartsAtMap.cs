using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class Tour_StartsAtMap : EntityTypeConfiguration<Tour_StartsAt>
    {
        public Tour_StartsAtMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Time)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Tour_StartsAt");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Time).HasColumnName("Time");
        }
    }
}
