using BillLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Repositories
{
    public interface IBillItems
    {
        Task AddNewbill(BillItems bill);
    }
}
