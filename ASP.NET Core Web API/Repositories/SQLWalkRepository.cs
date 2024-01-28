using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Models.Domain;

namespace ASP.NET_Core_Web_API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly AspNetCoreWebApiDbContext aspNetCoreWebApiDbContext;

        public SQLWalkRepository(AspNetCoreWebApiDbContext aspNetCoreWebApiDbContext)
        {
            this.aspNetCoreWebApiDbContext = aspNetCoreWebApiDbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await aspNetCoreWebApiDbContext.Walks.AddAsync(walk);
            await aspNetCoreWebApiDbContext.SaveChangesAsync();
            return walk;
        }
    }
}
