using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using trello.api.Models;
using trello.api.Service.Panel;

namespace trello.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelController : ControllerBase
    {
        private readonly IPanelService _service; 

        public PanelController(IPanelService service)
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
        public ActionResult Save([FromBody] PanelModel panel)
        {
            try
            {
                if (panel == null) {
                    throw new Exception("Error #001");
                }

                var panelReturn = _service.Save(panel);

                return Ok(panelReturn);
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