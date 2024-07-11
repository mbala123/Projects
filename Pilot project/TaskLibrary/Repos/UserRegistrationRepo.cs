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
    /// Implementation of user registration interface is done
    /// </summary>
    public class UserRegistrationRepo : IUserRegistration
    {
        ListDBContext ctx = new ListDBContext();

        /// <summary>
        /// Get all user lists
        /// </summary>
        /// <returns List of all user list></returns>
        public async Task<List<UserRegistration>> GetAll()
        {
            List<UserRegistration> list=await ctx.UserRegistrations.ToListAsync();
            return list;
        }

        /// <summary>
        /// Get one user details for given username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns Detail of one user></returns>
        public async Task<UserRegistration> GetOne(string userName)
        {
            UserRegistration reg=await (from s in ctx.UserRegistrations where s.UserName == userName select s).FirstAsync();
            return reg;
        }

        /// <summary>
        /// For registering new user
        /// </summary>
        /// <param name="registration"></param>
        /// <returns Creating new user></returns>
        public async Task Register(UserRegistration registration)
        {
           
            await ctx.UserRegistrations.AddAsync(registration);
            registration.CreatedOn = DateTime.Now;
            await ctx.SaveChangesAsync();
        }

        /// <summary>
        /// Update the password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public async Task UpdatePassword(string userName,string newPassword)
        {
            UserRegistration user=await GetOne(userName);
            user.Password = newPassword;
            await ctx.SaveChangesAsync();
        }
    }
}
