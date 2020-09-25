using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using trello.api.Models;
using trello.api.Service.User;

namespace trello.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _service { get; set; }

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IList<UserModel>> Get()
        {
            try
            {
                var _users = _service.Get();

                return Ok(_users); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                if (id == 0) {
                    throw new Exception("id inválido");
                }

                var user = _service.Get(id);

                return Ok(user); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPost("Save")]
        public ActionResult Save([FromBody] UserModel user)
        {
            try
            {
                if (User == null) {
                    throw new Exception("parametros inválidos");
                }

                var userOut = _service.Save(user);

                return Ok(userOut); 
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
                if (id == 0) {
                    throw new Exception("id inválido");
                }

                _service.Remove(id);

                return Ok( new { removed = true} ); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}