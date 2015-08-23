using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class TourMap : EntityTypeConfiguration<Tour>
    {
        public TourMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.title)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Tour");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.userID).HasColumnName("userID");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.Tours)
                .HasForeignKey(d => d.userID);

        }
    }
}
