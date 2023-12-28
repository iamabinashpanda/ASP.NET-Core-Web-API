using ASP.NET_Core_Web_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data
{
    public class AspNetCoreWebApiDbContext : DbContext
    {
        public AspNetCoreWebApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Difficulty> difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
