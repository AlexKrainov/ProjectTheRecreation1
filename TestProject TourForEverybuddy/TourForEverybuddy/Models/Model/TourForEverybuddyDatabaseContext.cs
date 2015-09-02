using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TourForEverybuddy.Models.Mapping;

namespace TourForEverybuddy.Models
{
    public partial class TourForEverybuddyDatabaseContext : DbContext
    {
        static TourForEverybuddyDatabaseContext()
        {
            Database.SetInitializer<TourForEverybuddyDatabaseContext>(null);
        }

        public TourForEverybuddyDatabaseContext()
            : base("Name=TourForEverybuddyDatabaseContext")
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<DaysOfTheWeek> DaysOfTheWeeks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Tour_Cities> Tour_Cities { get; set; }
        public DbSet<Tour_CommentOfTour> Tour_CommentOfTour { get; set; }
        public DbSet<Tour_DaysOfTheWeek> Tour_DaysOfTheWeek { get; set; }
        public DbSet<Tour_Duration> Tour_Duration { get; set; }
        public DbSet<Tour_PictureOfTour> Tour_PictureOfTour { get; set; }
        public DbSet<Tour_StartsAt> Tour_StartsAt { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new DaysOfTheWeekMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TourMap());
            modelBuilder.Configurations.Add(new Tour_CitiesMap());
            modelBuilder.Configurations.Add(new Tour_CommentOfTourMap());
            modelBuilder.Configurations.Add(new Tour_DaysOfTheWeekMap());
            modelBuilder.Configurations.Add(new Tour_DurationMap());
            modelBuilder.Configurations.Add(new Tour_PictureOfTourMap());
            modelBuilder.Configurations.Add(new Tour_StartsAtMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserLanguageMap());
            modelBuilder.Configurations.Add(new UserTypeMap());
        }
    }
}
