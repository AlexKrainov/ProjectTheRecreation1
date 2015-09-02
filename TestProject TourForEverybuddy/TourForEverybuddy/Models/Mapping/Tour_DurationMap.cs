using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class Tour_DurationMap : EntityTypeConfiguration<Tour_Duration>
    {
        public Tour_DurationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Time)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.TimeRus)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Tour_Duration");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.TimeRus).HasColumnName("TimeRus");
        }
    }
}
