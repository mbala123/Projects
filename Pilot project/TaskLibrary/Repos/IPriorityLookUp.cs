using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Models;

namespace TaskLibrary.Repos
{
    /// <summary>
    /// This Prioritylookup interface is implemented by prioritylookup repo
    /// </summary>
    public interface IPriorityLookUp    
    {
        Task<List<PriorityLookUp>> GetAllPriorities();
    }
}
