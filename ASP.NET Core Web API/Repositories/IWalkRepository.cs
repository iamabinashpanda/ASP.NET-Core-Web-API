using ASP.NET_Core_Web_API.Models.Domain;

namespace ASP.NET_Core_Web_API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
    }
}
