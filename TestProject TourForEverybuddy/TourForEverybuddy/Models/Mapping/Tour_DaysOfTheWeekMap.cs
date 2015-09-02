using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class Tour_DaysOfTheWeekMap : EntityTypeConfiguration<Tour_DaysOfTheWeek>
    {
        public Tour_DaysOfTheWeekMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Tour_DaysOfTheWeek");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DaysOfTheWeekID).HasColumnName("DaysOfTheWeekID");
            this.Property(t => t.TourID).HasColumnName("TourID");

            // Relationships
            this.HasRequired(t => t.DaysOfTheWeek)
                .WithMany(t => t.Tour_DaysOfTheWeek)
                .HasForeignKey(d => d.DaysOfTheWeekID);
            this.HasRequired(t => t.Tour)
                .WithMany(t => t.Tour_DaysOfTheWeek)
                .HasForeignKey(d => d.TourID);

        }
    }
}
