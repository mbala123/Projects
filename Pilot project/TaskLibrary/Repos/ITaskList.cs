using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Models;

namespace TaskLibrary.Repos
{
    /// <summary>
    /// This tasklist interface is implemented by tasklist repo
    /// </summary>
    public interface ITaskList
    {
        Task <List<TaskList>> GetAllLists();
        Task <List<TaskList>> GetListsByUserId(int userId);
        Task<TaskList> GetOne(int listId);
        Task<List<TaskList>> GetListsByTaskDate(int userId, DateOnly taskDate);
        Task<List<TaskList>> GetListsByStatus(int userId,int statusId);
        Task<List<TaskList>> GetListsByPriority(int userId,int priorityId);
        Task InsertNewTask(TaskList task);
        Task UpdateTask(int taskId, TaskList task);
        Task DeleteTask(int taskId);
    }
}
