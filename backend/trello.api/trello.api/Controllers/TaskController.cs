using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trello.api.Models;
using trello.api.Service.Task;

namespace trello.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service; 
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { success = "Ok" });
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var response = _service.Get(id); 

                return Ok(response); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpPost("Save")]
        public ActionResult<TaskModel> Save([FromBody] TaskModel task)
        {   
            try
            {
                if (task == null) {
                    throw new Exception("Parametros Inválidos");
                }

                var taskCreated = _service.Save(task); 

                return Ok(taskCreated); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPut]
        public void Put([FromBody] TaskModel task)
        {
            try
            {
                if (task == null) {
                    throw new Exception("Parametros Inválidos");
                }

                _service.Save(task); 

                Ok(); 
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}