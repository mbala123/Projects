using Microsoft.AspNetCore.Mvc.Rendering;
using TaskLibrary.Models;
using TaskLibrary.Repos;

namespace TaskListMVC.Models
{
    public class ForeignKeyHelper
    {
        /// <summary>
        /// To show in drop down for status type
        /// </summary>
        /// <returns></returns>
        public static async Task<List<SelectListItem>> GetByStatusId()
        {
            List<SelectListItem> statusIds = new List<SelectListItem>();
            IStatusLookUp statusId = new StatusLookUpRepo();
            List<StatusLookUp> statuses = await statusId.GetAllStatus();
            foreach (StatusLookUp status in statuses)
            {
                statusIds.Add(new SelectListItem { Text = status.StatusType, Value = status.StatusId.ToString() });
            }
            return statusIds;
        }

        /// <summary>
        /// To show in drop down for priority type
        /// </summary>
        /// <returns></returns>
        public static async Task<List<SelectListItem>> GetByPriorityId()
        {
            List<SelectListItem> priorityIds = new List<SelectListItem>();
            IPriorityLookUp priorityId = new PriorityLookUpRepo();
            List<PriorityLookUp> priorities = await priorityId.GetAllPriorities();
            foreach (PriorityLookUp priority in priorities)
            {
                priorityIds.Add(new SelectListItem { Text = priority.PriorityType, Value = priority.PriorityId.ToString() });
            }
            return priorityIds;
        }
    }
}
