using BillLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Repositories
{
    public class BillItemsRepository : IBillItems
    {
        BillDbContext dbContext=new BillDbContext();
        public async Task AddNewbill(BillItems bill)
        {
            await dbContext.AddAsync(bill);
            await dbContext.SaveChangesAsync();
        }
    }
}
