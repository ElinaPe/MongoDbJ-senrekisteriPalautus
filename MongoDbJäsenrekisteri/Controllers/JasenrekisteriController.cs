using Microsoft.AspNetCore.Mvc;
using MongoDbJäsenrekisteri.Models;
using MongoDbJäsenrekisteri.Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDbJäsenrekisteri.Controllers
{
    [Route("api/jasenet")]
    [ApiController]
    public class JasenrekisteriController : ControllerBase
    {
        private readonly JasenService _jasenService;

        public JasenrekisteriController(JasenService jasenService) => _jasenService = jasenService;

        [HttpGet]
        [Route("")]
        public async Task<List<Jasen>> Get() =>
            await _jasenService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Jasen newJasen)
        {
            await _jasenService.CreateAsync(newJasen);
            return CreatedAtAction(nameof(Get), new { id = newJasen.Id }, newJasen);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Jasen>> Get(string id)
        {
            var jasen = await _jasenService.GetAsync(id);
            if (jasen == null)
            {
                return NotFound();
            }
            return jasen;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, Jasen updateJasen)
        {
            var jasen = await _jasenService.GetAsync(id);

            if (jasen is null)
            {
                return NotFound();
            }
            updateJasen.Id = jasen.Id;
            await _jasenService.UpdateAsync(id, updateJasen);
            return NoContent();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var jasen = await _jasenService.GetAsync(id);
            if (jasen is null)
            {
                return NotFound();
            }

            await _jasenService.RemoveAsync(id);
            return NoContent();
        }
    }
}
