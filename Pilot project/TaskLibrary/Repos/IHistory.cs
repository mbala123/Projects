using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Models;

namespace TaskLibrary.Repos
{
    /// <summary>
    /// This interface history will be implemented by HistoryRepo
    /// </summary>
    public interface IHistory
    {
        Task<List<History>> GetAllHistories();
        Task<List<History>> GetHistoriesByUserId(int userId);
        Task<List<History>> GetHistoriesByTaskId(int userId, int taskId);
        Task<List<History>> GetHistoriesByStatusId(int userId,int statusId);
        Task<List<History>> GetHistoriesByPriorityId(int userId, int priorityId);
        Task InsertNewHistory(TaskList task);
        Task UpdateTaskInsertHistory(int statusId, TaskList task);
    }
}
