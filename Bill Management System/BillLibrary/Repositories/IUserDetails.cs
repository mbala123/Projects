using BillLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Repositories
{
    public interface IUserDetails
    {
        Task AddNewUser(UserDetails user);
    }
}
