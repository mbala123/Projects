using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Models;

namespace TaskLibrary.Repos
{
    /// <summary>
    /// This Statuslookup interface is implemented by statuslookup repo
    /// </summary>
    public interface IStatusLookUp
    {
        Task<List<StatusLookUp>> GetAllStatus();
    }
}
