using BillLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Repositories
{
    public class UserItemsRepository : IUserDetails
    {
        BillDbContext dbContext = new BillDbContext();
        public async Task AddNewUser(UserDetails user)
        {
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
