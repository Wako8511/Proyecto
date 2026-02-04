using System.Collections.Generic;
using Proyecto.Models;

namespace Proyecto.Interfaces
{
    public interface ITaskServices
    {
        void AddTask(TaskModel task);
        TaskModel UpdateTask(int taskId, TaskModel task);
        void CompleteTask(int taskId);
        void DeleteTask(int taskId);
        List<TaskModel> GetAllTasks();
    }
}
