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
    /// Implementation of Status look up interface should be done
    /// </summary>
    public class StatusLookUpRepo :IStatusLookUp
    {
        ListDBContext ctx = new ListDBContext();

        /// <summary>
        /// Get all statuses for foreign key helper
        /// </summary>
        /// <returns List of all status></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<StatusLookUp>> GetAllStatus()
        {
            try
            {
                List<StatusLookUp> lists = await ctx.StatusLookUps.ToListAsync();
                return lists;
            }
            catch (Exception ex)
            {
                throw new Exception("No Status Available");
            }
        }
    }
}
