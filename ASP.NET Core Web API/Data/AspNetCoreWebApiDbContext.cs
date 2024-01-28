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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data for difficulty
            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("d000c5d0-96a2-48c6-b68a-8a49619851eb"),
                    Name = "Easy",

                },
                new Difficulty
                {
                    Id = Guid.Parse("509cc4c3-0ee9-4a90-8ffa-4fa335691cce"),
                    Name = "Medium",

                },
                new Difficulty
                {
                    Id = Guid.Parse("38e794c0-6acc-45af-a403-b46eb05a07a1"),
                    Name = "Hard",

                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>
            {
               new Region
               {
                   Id = Guid.Parse("d25b5e29-6ed4-49b9-8b49-f675c5763c10"),
                    Name = "Region 1",
                    Code = "R1",
                    RegionImageUrl = "https://example.com/region1-image.jpg"
               },
               new Region
               {
                   Id = Guid.Parse("a7f027c3-aea1-4af8-a756-a05409334e59"),
                   Name = "Region 2",
                   Code = "R2",
                   RegionImageUrl = "https://example.com/region2-image.jpg"
               },
               new Region
               {
                   Id = Guid.Parse("fd8b8ef3-d85c-4c16-9e09-d12e41d20763"),
                   Name = "Region 3",
                   Code = "R3",
                   RegionImageUrl = "https://example.com/region3-image.jpg"
               },
               new Region
               {
                   Id = Guid.Parse("1a66c0c7-2154-4175-9452-fbdd13961cc7"),
                   Name = "Region 4",
                   Code = "R4",
                   RegionImageUrl = "https://example.com/region4-image.jpg"
               },
               new Region
               {
                   Id = Guid.Parse("3834b42f-b6aa-47f5-8da3-e6fa262f1d49"),
                   Name = "Region 5",
                   Code = "R5",
                   RegionImageUrl = "https://example.com/region5-image.jpg"
               }

            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
