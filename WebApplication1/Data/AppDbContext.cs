using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Groups_Class> Groups_Class { get; set; } = default!;
        public DbSet<WebApplication1.Models.Items_Class> Items_Class { get; set; } = default!;
    }
}
