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
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.description)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Tour");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.disable).HasColumnName("disable");
            this.Property(t => t.cityID).HasColumnName("cityID");
            this.Property(t => t.fullDescription).HasColumnName("fullDescription");
            this.Property(t => t.MaximumTravelers).HasColumnName("MaximumTravelers");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.durationID).HasColumnName("durationID");
            this.Property(t => t.startAtID).HasColumnName("startAtID");

            // Relationships
            this.HasRequired(t => t.Tour_Cities)
                .WithMany(t => t.Tours)
                .HasForeignKey(d => d.cityID);
            this.HasOptional(t => t.Tour_Duration)
                .WithMany(t => t.Tours)
                .HasForeignKey(d => d.durationID);
            this.HasOptional(t => t.Tour_StartsAt)
                .WithMany(t => t.Tours)
                .HasForeignKey(d => d.startAtID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Tours)
                .HasForeignKey(d => d.userID);

        }
    }
}
