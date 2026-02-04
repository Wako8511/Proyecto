using Microsoft.AspNetCore.Mvc;
using Proyecto.Interfaces;
using Proyecto.Models;
using System;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/tareas")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;

        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_taskServices.GetAllTasks());
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskModel task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _taskServices.AddTask(task);
                return CreatedAtAction(nameof(GetAllTasks), task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}/completar")]
        public IActionResult CompleteTask(int id)
        {
            try
            {
                _taskServices.CompleteTask(id);
                return Ok("Tarea completada correctamente");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                _taskServices.DeleteTask(id);
                return Ok("Tarea eliminada correctamente");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
