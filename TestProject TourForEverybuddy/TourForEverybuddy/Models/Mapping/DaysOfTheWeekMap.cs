using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class DaysOfTheWeekMap : EntityTypeConfiguration<DaysOfTheWeek>
    {
        public DaysOfTheWeekMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.NameRus)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("DaysOfTheWeek");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NameRus).HasColumnName("NameRus");
            this.Property(t => t.Code).HasColumnName("Code");
        }
    }
}
