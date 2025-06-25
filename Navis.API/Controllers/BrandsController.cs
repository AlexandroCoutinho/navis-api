using Microsoft.AspNetCore.Mvc;
using Navis.Application.Models.Brand;
using Navis.Application.Services.Interfaces;

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
            await Task.FromResult(0);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BrandCreateModel brandCreateModel)
        {
            var brandReadModel = await _brandApplicationService.CreateAsync(brandCreateModel);
            return CreatedAtAction(nameof(Get), new { id = brandReadModel.Id }, brandReadModel);
        }
    }
}
