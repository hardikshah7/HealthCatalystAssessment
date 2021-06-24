using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HealthCatalystAssessment.Models;

namespace HealthCatalystAssessment.Data
{
    public class HealthCatalystAssessmentContext : DbContext
    {
        public HealthCatalystAssessmentContext (DbContextOptions<HealthCatalystAssessmentContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Seed();
        }

        public virtual DbSet<User> User { get; set; }
    }

    public static class ModelBuilderExtensions
    {
        // Seed the database with some records.
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var user1Guid = Guid.NewGuid();
            var user2Guid = Guid.NewGuid();
            var user3Guid = Guid.NewGuid();
            modelBuilder.Entity<User>(b =>
            {
                b.HasData(new User
                {
                    Id = user1Guid,
                    FirstName = "Hardik",
                    LastName = "Shah",
                    Address = "Oregon",
                    Age = 30
                });
                b.OwnsMany(i => i.Interests)
                    .HasData(new List<Interest>
                    {
                        new Interest {Id = Guid.NewGuid(), UserId = user1Guid, Activity = "Video Games"},
                        new Interest {Id = Guid.NewGuid(), UserId = user1Guid, Activity = "Biking"},
                        new Interest {Id = Guid.NewGuid(), UserId = user1Guid, Activity = "Software Development"}
                    });
            });

            modelBuilder.Entity<User>(b =>
            {
                b.HasData(new User
                {
                    Id = user2Guid,
                    FirstName = "Jack",
                    LastName = "Sparrow",
                    Address = "Carribean",
                    Age = 35
                });
                b.OwnsMany(i => i.Interests)
                    .HasData(new List<Interest>
                    {
                        new Interest {Id = Guid.NewGuid(), UserId = user2Guid, Activity = "Black Pearl"},
                        new Interest {Id = Guid.NewGuid(), UserId = user2Guid, Activity = "Treasure hunting"},
                        new Interest {Id = Guid.NewGuid(), UserId = user2Guid, Activity = "Sea Adventures"}
                    });
            });

            modelBuilder.Entity<User>(b =>
            {
                b.HasData(new User
                {
                    Id = user3Guid,
                    FirstName = "Harry",
                    LastName = "Potter",
                    Address = "Hogwarts",
                    Age = 20
                });
                b.OwnsMany(i => i.Interests)
                    .HasData(new List<Interest>
                    {
                        new Interest {Id = Guid.NewGuid(), UserId = user3Guid, Activity = "Quidditch"},
                        new Interest {Id = Guid.NewGuid(), UserId = user3Guid, Activity = "Magic"},
                        new Interest {Id = Guid.NewGuid(), UserId = user3Guid, Activity = "Butterbeer"}
                    });
            });
        }
    }
}
