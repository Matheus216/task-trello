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
        public ActionResult<IList<CheckModel>> Get()
        {
            try
            {
                var response = _service.Get();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CheckModel> Get(int id)
        {
            try
            {
                if (id == 0) {
                    throw new Exception("id inválido.");
                }

                var response = _service.Get(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPost("Save")]
        public ActionResult Post([FromBody] CheckModel check)
        {
            try
            {
                if (check == null)
                    throw new Exception("Parametros de entrada inválidos");

                var response = _service.Save(check);

                return Ok(response);
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
                if (id == 0){
                    throw new Exception("id inválido.");
                }

                _service.Remove(id);
                
                return Ok( new { removed = true } );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}