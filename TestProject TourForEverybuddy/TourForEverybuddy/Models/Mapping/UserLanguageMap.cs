using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TourForEverybuddy.Models.Mapping
{
    public class UserLanguageMap : EntityTypeConfiguration<UserLanguage>
    {
        public UserLanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserLanguage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");

            // Relationships
            this.HasOptional(t => t.Language)
                .WithMany(t => t.UserLanguages)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserLanguages)
                .HasForeignKey(d => d.UserID);

        }
    }
}
