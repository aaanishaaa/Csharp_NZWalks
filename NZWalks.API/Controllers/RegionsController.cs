using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET ALL REGIONS
        [HttpGet] 
        public IActionResult GetAll()
        {
            //Get data from database ie from domain models
            var regionsdomain = dbContext.Regions.ToList();
            //Map models to DTO 
            var regionsDto = regionsdomain.Select(region => new Models.DTO.RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            }).ToList();
            //Return the DTOs
            return Ok(regionsDto);
        }
        // GET BY ID
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            //Get data from database ie from domain models
            var regionsdomain =dbContext.Regions.Find(id);
            if (regionsdomain == null)
            {
                return NotFound();
            }
            // Map region domain models to Region DTO
            var regionDto = new RegionDto
            {
                Id = regionsdomain.Id,
                Code = regionsdomain.Code,
                Name = regionsdomain.Name,
                RegionImageUrl = regionsdomain.RegionImageUrl
            };
             return Ok(regionDto);
        }

        // POST to create a New Region
        [HttpPost]
        public IActionResult Create([FromBody]AddRegionRequestDto addRegionRequestDto)
        {
            // Map DTO to Domain Model

            var regionDomainmodel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name=addRegionRequestDto.Name,
                RegionImageUrl=addRegionRequestDto.RegionImageUrl
            };

            //USE Domain Model to Create Region
            dbContext.Regions.Add(regionDomainmodel);
            dbContext.SaveChanges();

            // Map domain model back to DTO
            var regionDTO = new RegionDto
            {
                Id = regionDomainmodel.Id,
                Code = regionDomainmodel.Code,
                Name = regionDomainmodel.Name,
                RegionImageUrl = regionDomainmodel.RegionImageUrl
            };
            // Return
            return CreatedAtAction(nameof(GetById), new { id = regionDomainmodel.Id }, regionDTO);

        }
        // Update region a particular region via ID
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto )
        {
            //check if region exists
            var regionDomainModel=dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            // Map DTO to Domain model
            regionDomainModel.Code= updateRegionRequestDto.Code;
            regionDomainModel.Name= updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl= updateRegionRequestDto.RegionImageUrl;
            dbContext.SaveChanges();
            // Convert Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return Ok(regionDto);
        }
        //Delete Region a single region
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            dbContext.Regions.Remove(regionDomainModel);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
