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
    

       
    }
}
