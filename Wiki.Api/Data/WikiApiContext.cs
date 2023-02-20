using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wiki.Api.Entities;

namespace Wiki.Api.Data
{
    public class WikiApiContext : DbContext
    {
        public DbSet<Character> Character { get; set; } = default!;
        public DbSet<TextBlock> TextBlock { get; set; } = default!;
        public WikiApiContext(DbContextOptions<WikiApiContext> options)
            : base(options)
        {
        }

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries<Character>().Where(e => e.State == EntityState.Modified))
        //    {
        //        entry.Property("Updated").CurrentValue = DateTime.Now;
        //    }

        //    foreach (var entry in ChangeTracker.Entries<Character>().Where(e => e.State == EntityState.Added))
        //    {
        //        entry.Property("Created").CurrentValue = DateTime.Now;
        //    }

        //    return base.SaveChanges();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Character>().Where(e => e.State == EntityState.Modified))
            {
                entry.Property("Updated").CurrentValue = DateTime.Now;
            }

            foreach (var entry in ChangeTracker.Entries<Character>().Where(e => e.State == EntityState.Added))
            {
                entry.Property("Created").CurrentValue = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
