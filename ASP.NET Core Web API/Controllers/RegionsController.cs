using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Models.Domain;
using ASP.NET_Core_Web_API.Models.DTO;
using ASP.NET_Core_Web_API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController( IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //GET ALL REGIONS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAllAsync();
            var regiondto = mapper.Map<List<RegionDTO>>(regions);
            return Ok(regiondto);
        }

        //GET SINGLE REGION BY ID
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regions = await regionRepository.GetByIdAsync(id);
            if (regions == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDTO>(regions));
        }
        //INSERT REGIONS
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDTO);
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id}, regionDTO);
        }

        //UPDATE REGION
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
            if(regionDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
        }
        //DELETE REGIONS
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
