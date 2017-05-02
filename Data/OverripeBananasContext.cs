using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OverripeBananas.Models;

namespace OverripeBananas.Models
{
    public class OverripeBananasContext : DbContext
    {
        public OverripeBananasContext (DbContextOptions<OverripeBananasContext> options)
            : base(options)
        {
        }

        public DbSet<OverripeBananas.Models.Show> Show { get; set; }

        public DbSet<OverripeBananas.Models.Episodes> Episodes { get; set; }
    }
}
