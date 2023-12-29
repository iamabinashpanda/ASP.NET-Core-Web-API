using ASP.NET_Core_Web_API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);

    }
}
