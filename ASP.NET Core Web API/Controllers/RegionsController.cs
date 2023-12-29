using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Models.Domain;
using ASP.NET_Core_Web_API.Models.DTO;
using ASP.NET_Core_Web_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AspNetCoreWebApiDbContext aspNetCoreWebApiDbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(AspNetCoreWebApiDbContext aspNetCoreWebApiDbContext, IRegionRepository regionRepository)
        {
            this.aspNetCoreWebApiDbContext = aspNetCoreWebApiDbContext;
            this.regionRepository = regionRepository;
        }

        //GET ALL REGIONS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var regions = await aspNetCoreWebApiDbContext.Regions.ToListAsync();
            var regions = await regionRepository.GetAllAsync();
            var regiondto = new List<RegionDTO>();
            foreach (var region in regions)
            {
                regiondto.Add(new RegionDTO() { Name = region.Name, Id = region.Id, Code = region.Code, RegionImageUrl = region.RegionImageUrl });
            }
            return Ok(regiondto);
        }

        //GET SINGLE REGION BY ID
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var regions = aspNetCoreWebApiDbContext.Regions.Find(id);
            var regions = await regionRepository.GetByIdAsync(id);
            if (regions == null)
            {
                return NotFound();
            }
            var regiondto = new RegionDTO
            {
                Name = regions.Name,
                RegionImageUrl = regions.RegionImageUrl,
                Code = regions.Code,
                Id = regions.Id
            };

            return Ok(regiondto);
        }
        //INSERT REGIONS
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomainModel = new Region
            {
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl,
                Code = addRegionRequestDTO.Code
            };

            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            var regionDTO = new RegionDTO { Name = regionDomainModel.Name, Id = regionDomainModel.Id, RegionImageUrl = regionDomainModel.RegionImageUrl, Code = regionDomainModel.Code };

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id}, regionDTO);
        }

        //UPDATE REGION
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            //var regionDomainModel = await aspNetCoreWebApiDbContext.Regions.FirstOrDefaultAsync(x=>x.Id == id);
            var regionDomainModel = new Region
            {
                Code = updateRegionRequestDTO.Code, Name = updateRegionRequestDTO.Name, RegionImageUrl = updateRegionRequestDTO.RegionImageUrl
            };
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            var regionDTO = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
                Code = regionDomainModel.Code
            };

            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
