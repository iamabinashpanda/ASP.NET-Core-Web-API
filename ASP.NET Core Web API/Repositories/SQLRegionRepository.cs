using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly AspNetCoreWebApiDbContext aspNetCoreWebApiDbContext;

        public SQLRegionRepository(AspNetCoreWebApiDbContext aspNetCoreWebApiDbContext)
        {
            this.aspNetCoreWebApiDbContext = aspNetCoreWebApiDbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await aspNetCoreWebApiDbContext.Regions.AddAsync(region);
            await aspNetCoreWebApiDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await aspNetCoreWebApiDbContext.Regions.FirstOrDefaultAsync(x=>x.Id == id);
            if(existingRegion == null)
            {
                return null;
            }
            aspNetCoreWebApiDbContext.Remove(existingRegion);
            await aspNetCoreWebApiDbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await aspNetCoreWebApiDbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await aspNetCoreWebApiDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await aspNetCoreWebApiDbContext.Regions.FirstOrDefaultAsync(x=>x.Id == id);
            if(existingRegion == null)
            {
                return null;
            }

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await aspNetCoreWebApiDbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
