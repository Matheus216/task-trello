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
                if (panel == null)
                {
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

        [HttpPut("{id}/{description}")]
        public ActionResult Put(int id, string description)
        {
             try
            {
                if (String.IsNullOrEmpty(description) || id == 0)
                {
                    throw new Exception("Error #001");
                }

                var panelReturn = _service.UpdateDescription(id, description);

                return Ok(panelReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Remove(id);

                return Ok( new { 
                    success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}