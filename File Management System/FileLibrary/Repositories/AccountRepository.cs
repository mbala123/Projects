using FileLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibrary.Repositories
{
    public class AccountRepository : IAccount
    {
        FileDbContext dbContext=new FileDbContext();
        public async Task<Account> GetOneAccount(string email)
        {
            try
            {
                Account account = await (from acc in dbContext.Accounts where acc.Email == email select acc).FirstAsync();
                return account;
            }
            catch
            {
                throw new Exception("No such account is available");
            }
        }

        public async Task InsertNewAccount(Account account)
        {
            account.CreatedOn = DateTime.Now;
            await dbContext.Accounts.AddAsync(account);
            await dbContext.SaveChangesAsync();
        }

        public async Task<(bool IsSuccess, string Message,int UserId,string UserName)> IsLogin(string email, string password)
        {
            Account account = await GetOneAccount(email);
            if (account == null)
            {
                return (false, "No such user",0,"");
            }
            else
            {
                if (account.Password == password)
                {
                    return (true, "Login successful", account.UserId, account.Name);
                }
                else
                {
                    return (false, "Password does not match",0,"");
                }
            }
        }

        public async Task<(bool IsSuccess,string Message)> SignUp(Account account)
        {
            try
            {
                Account acc = await GetOneAccount(account.Email);                
                return (false, "User already exists");
                
            }
            catch(Exception ex)
            {
                await InsertNewAccount(account);
                return (true, "Account created successfully");
            }
           
        }

    }
}
