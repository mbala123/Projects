using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Models;
using TaskLibrary.Repos;

namespace TaskLibrary.Repos
{
    /// <summary>
    /// Implementation of task list interface is done
    /// </summary>
    public class TaskListRepo : ITaskList
    {
        //To Access the db context and history interface it is used
        ListDBContext ctx=new ListDBContext();
        IHistory repo=new HistoryRepo();

        /// <summary>
        /// Deleting the task by changing the status id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task DeleteTask(int taskId)
        {
           TaskList task=await GetOne(taskId);
            task.StatusId = 5;
            await UpdateTask(taskId, task);
        }

        /// <summary>
        /// Get all task lists
        /// </summary>
        /// <returns List of all tasks></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<TaskList>> GetAllLists()
        {
            try
            {
                List<TaskList> lists = await ctx.Tasks.Include(task=>task.StatusLookUp).Include(task=>task.PriorityLookUp).OrderBy(task=>task.PriorityId).ToListAsync();
                return lists;
            }
            catch (Exception ex)
            {
                throw new Exception("No Lists are available");
            }
        }

        /// <summary>
        /// Get task lists for given status for particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="statusId"></param>
        /// <returns List of task based on given status></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<TaskList>> GetListsByStatus(int userId, int statusId)
        {
            try
            {
                List<TaskList> lists = await (from s in ctx.Tasks where s.StatusId == statusId && s.UserId==userId select s).Include(task => task.StatusLookUp).Include(task => task.PriorityLookUp).OrderBy(task=>task.PriorityId).ToListAsync();
                return lists;
            }
            catch (Exception ex)
            {
                throw new Exception("No Lists are available for given status");
            }
        }
        /// <summary>
        /// Get task lists for given priority for particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="priorityId"></param>
        /// <returns List of task based on given priority></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<TaskList>> GetListsByPriority(int userId, int priorityId)
        {
            try
            {
                List<TaskList> lists = await (from s in ctx.Tasks where s.PriorityId == priorityId &&s.UserId==userId select s).Include(task => task.StatusLookUp).Include(task => task.PriorityLookUp).OrderBy(task=>task.PriorityId).ToListAsync();
                return lists;
            }
            catch (Exception ex)
            {
                throw new Exception("No Lists are available for given priority");
            }
        }
        /// <summary>
        /// Get task lists for given task date for particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskDate"></param>
        /// <returns List of task based on given task date></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<TaskList>> GetListsByTaskDate(int userId,DateOnly taskDate)
        {
            try
            {
                List<TaskList> lists=await (from s in ctx.Tasks where DateOnly.FromDateTime(s.TaskDate) == taskDate && s.UserId==userId select s).Include(task => task.StatusLookUp).Include(task => task.PriorityLookUp).OrderBy(task=>task.PriorityId).ToListAsync();
                return lists;
            }
            catch(Exception ex)
            {
                throw new Exception("No Lists are available for given date");
            }
        }

        /// <summary>
        /// Get task lists for given user 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns List of task based on given user></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<TaskList>> GetListsByUserId(int userId)
        {
            try
            {
                List<TaskList> lists = await (from s in ctx.Tasks where s.UserId == userId &&s.StatusId!=5 select s).Include(task=>task.StatusLookUp).Include(task=>task.PriorityLookUp).OrderBy(task=>task.PriorityId).ToListAsync();
                return lists;
            }
            catch (Exception ex)
            {
                throw new Exception("No Lists are available for given user");
            }
        }

        //
        /// <summary>
        /// Get task details for given task id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns Detail of one particular task></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TaskList> GetOne(int taskId)
        {
            try
            {
                TaskList task = await (from s in ctx.Tasks where s.TaskId == taskId select s).Include(task => task.StatusLookUp).Include(task => task.PriorityLookUp).FirstAsync();
                return task;
            }
            catch (Exception ex)
            {
                throw new Exception("No such Task");
            }
        }
        /// <summary>
        /// Insert new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task InsertNewTask(TaskList task)
        {
            await ctx.Tasks.AddAsync(task);
            await ctx.SaveChangesAsync();            
            await repo.InsertNewHistory(task);
        }

        /// <summary>
        /// Update the existing task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateTask(int taskId, TaskList task)
        {
            try
            {
                TaskList list = await GetOne(taskId);
                int statusId= list.StatusId;
                list.TaskDate = task.TaskDate;
                list.TaskDescription = task.TaskDescription;
                list.TaskName = task.TaskName;
                list.StatusId = task.StatusId;
                list.PriorityId = task.PriorityId;
                await ctx.SaveChangesAsync();             
                await repo.UpdateTaskInsertHistory(statusId, list);
            }
            catch(Exception ex)
            {
                throw new Exception("Enter valid Task");
            }
        }
    }
}
