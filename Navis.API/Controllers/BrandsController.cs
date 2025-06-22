using Microsoft.AspNetCore.Mvc;
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


        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var result = await _brandApplicationService.CreateAsync();
        //    return Ok("TESTE");
        //}

        //// GET api/<BrandsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var result = await _brandApplicationService.CreateAsync(new Application.Models.BrandCreateModel());
            return Created(); //Return URI
        }

        //// PUT api/<BrandsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BrandsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
