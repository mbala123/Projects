using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Models;

namespace TaskLibrary.Repos
{
    /// <summary>
    /// Implementation of priority look up interface is done
    /// </summary>
    public class PriorityLookUpRepo : IPriorityLookUp
    {
        ListDBContext ctx = new ListDBContext();

        /// <summary>
        /// Get all priorities for foreign key helper
        /// </summary>
        /// <returns List of all priorities></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<PriorityLookUp>> GetAllPriorities()
        {
            try
            {
                List<PriorityLookUp> lists = await ctx.PriorityLookUps.ToListAsync();
                return lists;
            }
            catch (Exception ex)
            {
                throw new Exception("No Priorities available");
            }
        }

       
    }
}
