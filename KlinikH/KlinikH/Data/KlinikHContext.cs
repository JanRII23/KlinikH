using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KlinikH.Models;

namespace KlinikH.Data
{
    public class KlinikHContext : DbContext
    {
        public KlinikHContext (DbContextOptions<KlinikHContext> options)
            : base(options)
        {
        }

        public DbSet<KlinikH.Models.Movie> Movie { get; set; } = default!;
    }
}
