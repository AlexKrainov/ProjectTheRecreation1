using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class Tour_PictureOfTourMap : EntityTypeConfiguration<Tour_PictureOfTour>
    {
        public Tour_PictureOfTourMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Picture)
                .IsRequired();

            this.Property(t => t.FileName)
                .HasMaxLength(150);

            this.Property(t => t.ContentType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tour_PictureOfTour");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TourID).HasColumnName("TourID");
            this.Property(t => t.Picture).HasColumnName("Picture");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.ContentType).HasColumnName("ContentType");

            // Relationships
            this.HasRequired(t => t.Tour)
                .WithMany(t => t.Tour_PictureOfTour)
                .HasForeignKey(d => d.TourID);

        }
    }
}
