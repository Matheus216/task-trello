using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using trello.api.Service;

namespace trello.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingController : ControllerBase
    {
        public PaintingService Service { get; set; }

        public PaintingController()
        {
            Service = new PaintingService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(Service.GetPainting());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}