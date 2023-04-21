using FlightAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace FlightAPI.DatabaseContext
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options) { }

        public FlightDbContext() { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Document_Type> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentFile> DocumentFiles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  Role Data
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    RoleName = "Admin"
                });

            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = 2,
                   RoleName = "Staff"
               });

            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = 3,
                   RoleName = "Pilot"
               });

            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = 4,
                   RoleName = "Stewardess"
               });

            //  Group Data
            modelBuilder.Entity<Group>().HasData(
               new Group()
               {
                   Id = 1,
                   GroupName = "Pilot",
                   CreateDate = Convert.ToDateTime("2021-01-10"),
                   Note = "Some note for pilot"
               });

            modelBuilder.Entity<Group>().HasData(
               new Group()
               {
                   Id = 2,
                   GroupName = "Stewardess",
                   CreateDate = Convert.ToDateTime("2021-01-10"),
                   Note = "Some notification for crew"
               });

            //  DocumentType Data
            modelBuilder.Entity<Document_Type>().HasData(
              new Document_Type()
              {
                  Id = 1,
                  Type_Name = "Load Summary",
                  CreateDate = Convert.ToDateTime("2021-01-10"),
                  Note = "Some note"
              });

            modelBuilder.Entity<Document_Type>().HasData(
              new Document_Type()
              {
                  Id = 2,
                  Type_Name = "Update Summary",
                  CreateDate = Convert.ToDateTime("2021-02-12"),
                  Note = "Some note for update"
              });

            //  Flight Data
            modelBuilder.Entity<Flight>().HasData(
              new Flight()
              {
                  Id = 1,
                  FlightCode = "VJ001",
                  LocationFrom = "Ha Noi",
                  LocationTo = "Ho Chi Minh",
                  DepartureDate = Convert.ToDateTime("2022-03-12")
              });

            modelBuilder.Entity<Flight>().HasData(
              new Flight()
              {
                  Id = 2,
                  FlightCode = "VJ002",
                  LocationFrom = "Ho Chi Minh",
                  LocationTo = "Con Dao",
                  DepartureDate = Convert.ToDateTime("2022-07-01")
              });

            //  User Data
            using (var hmac = new HMACSHA512())
            {
                modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = 1,
                        Username = "Admin",
                        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("string")),
                        PasswordSalt = hmac.Key,
                        Email = "Admin@vietjetair.com",
                        Phone = "098765421",
                        RoleID = 1,
                        VerificationOTP = "773198",
                        VerifiedAt = Convert.ToDateTime("2023 - 04 - 17"),
                    });

                modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = 2,
                        Username = "GO Employee",
                        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("string")),
                        PasswordSalt = hmac.Key,
                        Email = "Staff@vietjetair.com",
                        Phone = "098765421",
                        RoleID = 2,
                        VerificationOTP = "538203",
                        VerifiedAt = Convert.ToDateTime("2023 - 04 - 17"),
                    });

                modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = 3,
                        Username = "Pilot",
                        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("string")),
                        PasswordSalt = hmac.Key,
                        Email = "Pilot@vietjetair.com",
                        Phone = "098765421",
                        RoleID = 3,
                        VerificationOTP = "345453",
                        VerifiedAt = Convert.ToDateTime("2023 - 04 - 17"),
                    });

                modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = 4,
                        Username = "Stewardess",
                        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("string")),
                        PasswordSalt = hmac.Key,
                        Email = "Stewardess@vietjetair.com",
                        Phone = "098765421",
                        RoleID = 4,
                        VerificationOTP = "773358",
                        VerifiedAt = Convert.ToDateTime("2023 - 04 - 17"),
                    });
            }

            //  Document Data
            modelBuilder.Entity<Document>().HasData(
                new Document()
                {
                    Id = 1,
                    Name = "Document 1",
                    CreateDate = Convert.ToDateTime("2022-03-11"),
                    Url = "~/files/News.xlsx",
                    Note = "Some note",
                    Version = "1.0",
                    FlightID = 1,
                    Document_TypeID = 1,
                    UserID = 1,
                    GroupID = 1
                });

            modelBuilder.Entity<Document>().HasData(
                new Document()
                {
                    Id = 2,
                    Name = "Document 2",
                    CreateDate = Convert.ToDateTime("2022-03-12"),
                    Url = "~/files/Characters.xlsx",
                    Note = "Update note",
                    Version = "1.1",
                    FlightID = 1,
                    Document_TypeID = 2,
                    UserID = 2,
                    GroupID = 2
                });

            modelBuilder.Entity<Document>().HasData(
                new Document()
                {
                    Id = 3,
                    Name = "Time line of Fight trip",
                    CreateDate = Convert.ToDateTime("2022-06-30"),
                    Url = "~/files/Users.xlsx",
                    Note = "Some note",
                    Version = "1.0",
                    FlightID = 2,
                    Document_TypeID = 1,
                    UserID = 2,
                    GroupID = 2
                });

            //  DocumentFile Data
            modelBuilder.Entity<DocumentFile>().HasData(
                new DocumentFile()
                {
                    Id = 1,
                    FileName = "Ganyu Picture",
                    CreateDate = Convert.ToDateTime("2022-06-30"),
                    Url = "~/files/Ganyu-1st prize.jpg",
                    DocumentID = 2,
                });

            modelBuilder.Entity<DocumentFile>().HasData(
                new DocumentFile()
                {
                    Id = 2,
                    FileName = "Fresher DOCX",
                    CreateDate = Convert.ToDateTime("2022-08-03"),
                    Url = "~/files/Fresher-.NET.docx",
                    DocumentID = 1,
                });

            modelBuilder.Entity<DocumentFile>().HasData(
                new DocumentFile()
                {
                    Id = 3,
                    FileName = "Mac Le Nin",
                    CreateDate = Convert.ToDateTime("2022-08-04"),
                    Url = "~/files/NỘI DUNG ÔN TẬP TRIẾT HỌC MLN.docx",
                    DocumentID = 2,
                });
        }
    }
}
