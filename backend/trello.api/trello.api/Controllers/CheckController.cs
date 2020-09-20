using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using trello.api.Models;
using trello.api.Service.Check;

namespace trello.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {

        private readonly ICheckService _service; 

        public CheckController(ICheckService service)
        {
            _service = service; 
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost("Save")]
        public ActionResult Post([FromBody] CheckModel check)
        {
            try
            {
                if (check == null)
                    throw new Exception("Parametros de entrada inválidos");

                var response = _service.Save(check);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
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