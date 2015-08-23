using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .HasMaxLength(150);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Age).HasColumnName("Age");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.RouleId).HasColumnName("RouleId");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.DateRegister).HasColumnName("DateRegister");
            this.Property(t => t.LastAuthorization).HasColumnName("LastAuthorization");

            // Relationships
            this.HasOptional(t => t.Country)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.CountryId);
            this.HasOptional(t => t.UserType)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.RouleId);

        }
    }
}
