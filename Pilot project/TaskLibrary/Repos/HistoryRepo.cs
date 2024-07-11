using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Models;

namespace TaskLibrary.Repos
{
    /// <summary>
    /// Implementation of history interface is done
    /// </summary>
    public class HistoryRepo:IHistory
    {
        ListDBContext ctx= new ListDBContext();
        
        /// <summary>
        /// Get all history
        /// </summary>
        /// <returns>List of all history</returns>
        public async Task<List<History>> GetAllHistories()
        {
            try
            {
                List<History> histories = await ctx.Histories.Include(history=>history.TaskList).Include(history => history.PreviousStatus).Include(history => history.PresentStatus).Include(history => history.PresentPriority).ToListAsync();
                return histories;
            }
            catch (Exception ex)
            {
                throw new Exception("No Histories are available");
            }
        }
        /// <summary>
        /// Get All histories by given priority id for particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="priorityId"></param>
        /// <returns List fo history by priority id></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<History>> GetHistoriesByPriorityId(int userId,int priorityId)
        {
            try
            {
                List<History> histories = await (from s in ctx.Histories where s.PriorityId == priorityId &&s.UserId==userId select s).Include(history=>history.TaskList).Include(history => history.PreviousStatus).Include(history => history.PresentStatus).Include(history => history.PresentPriority).ToListAsync();
                return histories;
            }
            catch (Exception ex)
            {
                throw new Exception("No Histories are available for given Priority");
            }
        }        
        /// <summary>
        /// Get all histories by given status id for particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="statusId"></param>
        /// <returns List of history by using status id></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<History>> GetHistoriesByStatusId(int userId,int statusId)
        {
            try
            {
                List<History> histories = await (from s in ctx.Histories where s.PresentStatusId == statusId && s.UserId == userId select s).Include(history => history.TaskList).Include(history => history.PreviousStatus).Include(history => history.PresentStatus).Include(history => history.PresentPriority).ToListAsync();
                return histories;
            }
            catch (Exception ex)
            {
                throw new Exception("No Histories are available for given status");
            }
        }        
        /// <summary>
        /// Get all histories by given task id for particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        /// <returns List of history by task id></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<History>> GetHistoriesByTaskId(int userId,int taskId)
        {
            try
            {
                List<History> histories = await (from s in ctx.Histories where s.TaskId == taskId && s.UserId == userId select s).Include(history => history.TaskList).Include(history => history.PreviousStatus).Include(history => history.PresentStatus).Include(history => history.PresentPriority).ToListAsync();
                return histories;
            }
            catch(Exception ex)
            {
                throw new Exception("No Histories are available for given task");
            }
        }
        /// <summary>
        /// Get all histories by given user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns List of History for given user></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<History>> GetHistoriesByUserId(int userId)
        {
            try
            {
                List<History> histories = await (from s in ctx.Histories where s.UserId == userId select s).Include(history => history.TaskList).Include(history => history.PreviousStatus).Include(history => history.PresentStatus).Include(history => history.PresentPriority).ToListAsync();
                return histories;
            }
            catch(Exception ex)
            {
                throw new Exception("No task available for given user");
            }
        }
        /// <summary>
        /// Insert new history into history table
        /// </summary>
        /// <param name="task"></param>
        /// <return></returns>
        public async Task InsertNewHistory(TaskList task)
        {
            History history = new History();
            history.TaskId = task.TaskId;
            history.UserId = task.UserId;
            history.PreviousStatusId = 1;
            history.PresentStatusId = task.StatusId;
            history.PriorityId = task.PriorityId;
            history.TimeStamp = DateTime.Now;
            history.CreatedBy = task.CreatedBy;
            history.CreatedOn = history.TimeStamp;
            await ctx.Histories.AddAsync(history);
            await ctx.SaveChangesAsync();
        }
        /// <summary>
        /// For any task update, new history will be inserted
        /// </summary>
        /// <param name="statusId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task UpdateTaskInsertHistory(int statusId,TaskList list)
        {
            History history = new History();
            history.TaskId = list.TaskId;
            history.UserId = list.UserId;
            history.PreviousStatusId = statusId;
            history.PresentStatusId = list.StatusId;
            history.PriorityId = list.PriorityId;
            history.TimeStamp = DateTime.Now;
            history.CreatedBy = list.CreatedBy;
            history.CreatedOn = list.CreatedOn;
            await ctx.Histories.AddAsync(history);
            await ctx.SaveChangesAsync();
        }      
    }
}
