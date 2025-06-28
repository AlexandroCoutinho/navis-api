using Microsoft.AspNetCore.Mvc;
using Navis.Application.ApplicationServices.Interfaces;
using Navis.Application.Models.Brand;
using Navis.Application.Models.Filters;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BrandCreateModel brandCreateModel)
        {
            var brandReadModel = await _brandApplicationService.CreateAsync(brandCreateModel);
            return CreatedAtAction(nameof(Get), new { id = brandReadModel.Id }, brandReadModel);
        }
    }
}
