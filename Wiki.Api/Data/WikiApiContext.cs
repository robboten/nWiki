using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wiki.Api;

namespace Wiki.Api.Data
{
    public class WikiApiContext : DbContext
    {
        public DbSet<Wiki.Api.Character> Character { get; set; } = default!;
        public WikiApiContext(DbContextOptions<WikiApiContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Character>().HasData(
                new Character()
                {
                    Id = 1,
                    Name = "Zev",
                    Quote = "Integer vehicula vitae velit quis semper. Aliquam porta erat sit amet aliquam lobortis. Vivamus et ligula eget justo pharetra sagittis. Fusce lorem ipsum, sagittis quis turpis a, maximus auctor ipsum.",
                    PortraitUrl = "https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/zev.png?raw=true",
                }
            );
            modelBuilder.Entity<Character>().HasData(
                new Character()
                {
                    Id = 2,
                    Name = "Alex",
                    Quote = "Integer vehicula vitae velit quis semper. Aliquam porta erat sit amet aliquam lobortis. Vivamus et ligula eget justo pharetra sagittis. Fusce lorem ipsum, sagittis quis turpis a, maximus auctor ipsum.",
                    PortraitUrl = "https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/alex.png?raw=true",
                }
            );
        }

       
    }
}
