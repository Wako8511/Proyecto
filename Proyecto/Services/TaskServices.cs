using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly List<TaskModel> tasks = new();

        public TaskServices() { }

        public void AddTask(TaskModel task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            task.Id = tasks.Count + 1;
            task.IsCompleted = false;
            tasks.Add(task);
        }

        public TaskModel UpdateTask(int taskId, TaskModel task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            var item = tasks.FirstOrDefault(t => t.Id == taskId);
            if (item == null) throw new ArgumentException("Tarea no encontrada", nameof(taskId));

            // Actualiza solo si vienen valores no vacíos
            if (!string.IsNullOrWhiteSpace(task.Title))
                item.Title = task.Title;
            if (!string.IsNullOrWhiteSpace(task.Description))
                item.Description = task.Description;

            return item;
        }

        public void CompleteTask(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) throw new ArgumentException("Tarea no encontrada", nameof(taskId));
            task.IsCompleted = true;
        }

        public void DeleteTask(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) throw new ArgumentException("Tarea no encontrada", nameof(taskId));
            tasks.Remove(task);
        }

        public List<TaskModel> GetAllTasks()
        {
            return tasks.ToList();
        }
    }
}
