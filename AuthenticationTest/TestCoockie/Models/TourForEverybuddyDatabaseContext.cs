using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TestCoockie.Models.Mapping;

namespace TestCoockie.Models
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

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
