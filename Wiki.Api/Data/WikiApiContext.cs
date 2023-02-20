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
    

       
    }
}
