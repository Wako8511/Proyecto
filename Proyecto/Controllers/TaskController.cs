using Microsoft.AspNetCore.Mvc;
using Proyecto.Interfaces;
using Proyecto.Models;
using Proyecto.DTOs;
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

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] UpdateTaskDto dto)
        {
            if (dto == null)
                return BadRequest("El objeto tarea no puede ser nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Mapear DTO a modelo y llamar al servicio
                var model = new TaskModel
                {
                    Title = dto.Title ?? string.Empty,
                    Description = dto.Description ?? string.Empty
                };

                var updated = _taskServices.UpdateTask(id, model);
                return Ok(updated);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
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
