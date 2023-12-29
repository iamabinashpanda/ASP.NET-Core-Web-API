using ASP.NET_Core_Web_API.Models.Domain;
using ASP.NET_Core_Web_API.Models.DTO;
using AutoMapper;
namespace ASP.NET_Core_Web_API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Region, AddRegionRequestDTO>().ReverseMap();
            CreateMap<Region, UpdateRegionRequestDTO>().ReverseMap();
        }
    }
}
