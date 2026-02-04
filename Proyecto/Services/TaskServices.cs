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

        public void AddTask(TaskModel task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            task.Id = tasks.Count + 1;
            task.IsCompleted = false;

            tasks.Add(task);
        }

        public void CompleteTask(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
                throw new ArgumentException("Tarea no encontrada");

            task.IsCompleted = true;
        }

        public void DeleteTask(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
                throw new ArgumentException("Tarea no encontrada");

            tasks.Remove(task);
        }

        public List<TaskModel> GetAllTasks()
        {
            return tasks.ToList();
        }
    }
}
