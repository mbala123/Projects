using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLibrary.Models;

namespace TaskLibrary.Repos
{
    /// <summary>
    /// User Registration interface is implemented by user registration repo
    /// </summary>
    public interface IUserRegistration
    {
        Task <UserRegistration> GetOne(string userName);
        Task<List<UserRegistration>> GetAll();
        Task Register(UserRegistration registration);
        Task UpdatePassword(string userName, string password);
    }
}
