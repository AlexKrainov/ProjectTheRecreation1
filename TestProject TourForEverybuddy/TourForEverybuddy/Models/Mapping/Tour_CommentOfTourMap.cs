using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class Tour_CommentOfTourMap : EntityTypeConfiguration<Tour_CommentOfTour>
    {
        public Tour_CommentOfTourMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Comment)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Tour_CommentOfTour");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TourID).HasColumnName("TourID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Comment).HasColumnName("Comment");

            // Relationships
            this.HasRequired(t => t.Tour)
                .WithMany(t => t.Tour_CommentOfTour)
                .HasForeignKey(d => d.TourID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Tour_CommentOfTour)
                .HasForeignKey(d => d.UserID);

        }
    }
}
