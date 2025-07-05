using Microsoft.AspNetCore.Mvc;
using Navis.Application.ApplicationModels;
using Navis.Application.ApplicationServices.Interfaces;

namespace Navis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelApplicationService _modelApplicationService;
        public ModelController(IModelApplicationService modelApplicationService)
        {
            _modelApplicationService = modelApplicationService;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ModelApplicationModel modelApplicationModel)
        {
            var createdModel = await _modelApplicationService.CreateAsync(modelApplicationModel);
            return CreatedAtAction(nameof(Get), new { id = createdModel.Id }, createdModel);
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
