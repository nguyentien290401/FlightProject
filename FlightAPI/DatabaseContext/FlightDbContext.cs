using FlightAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightAPI.DatabaseContext
{
    public class FlightDbContext: DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options): base(options) { }

        public FlightDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Username = "Admin",
                Email = "Admin@vietjetair.com",
                Password = "123456",
                Phone = "0123456789",
                RoleName = "ADMIN"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 2,
                Username = "GO Employee",
                Email = "Staff@vietjetair.com",
                Password = "123456",
                Phone = "0123456789",
                RoleName = "GO"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 3,
                Username = "Pilot",
                Email = "Pilot@vietjetair.com",
                Password = "123456",
                Phone = "0987654321",
                RoleName = "PILOT"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 4,
                Username = "Crew",
                Email = "Crew@vietjetair.com",
                Password = "123456",
                Phone = "0987654321",
                RoleName = "CREW"
            });

            modelBuilder.Entity<Document>().HasData(new Document()
            {
                Id = 1,
                Name = "VJ001",
                CreateDate = Convert.ToDateTime("2022-02-24"),
                Note = "Go to Tokyo",
                Version = "1.0"
            });
            modelBuilder.Entity<Document>().HasData(new Document()
            {
                Id = 2,
                Name = "VJ002",
                CreateDate = Convert.ToDateTime("2022-04-29"),
                Note = "Go to Osaka",
                Version = "1.0"
            });
            modelBuilder.Entity<Document>().HasData(new Document()
            {
                Id = 3,
                Name = "VJ003",
                CreateDate = Convert.ToDateTime("2022-09-28"),
                Note = "Go to Kyoto",
                Version = "1.0"
            });
        }
    }
}
