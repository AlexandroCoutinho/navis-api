using Microsoft.AspNetCore.Mvc;
using Navis.Application.ApplicationModels.Brand;
using Navis.Application.ApplicationModels.Filters;
using Navis.Application.ApplicationServices.Interfaces;

namespace Navis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandApplicationService _brandApplicationService;

        public BrandsController(IBrandApplicationService brandApplicationService)
        {
            _brandApplicationService = brandApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BrandApplicationModel brandApplicationModel)
        {
            var createdBrand = await _brandApplicationService.CreateAsync(brandApplicationModel);
            return CreatedAtAction(nameof(Get), new { id = createdBrand.Id }, createdBrand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var brandReadModel = await _brandApplicationService.ReadByIdAsync(id);
            return Ok(brandReadModel);
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] BrandFilterModel brandFilterModel)
        {
            var pagedResultModel = await _brandApplicationService.ReadPagedResultAsync(brandFilterModel);
            return Ok(pagedResultModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] BrandApplicationModel brandApplicationModel)
        {
            var updatedBrand = await _brandApplicationService.UpdateAsync(brandApplicationModel);
            return NoContent();
        }
    }
}
