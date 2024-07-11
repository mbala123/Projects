using FileLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibrary.Repositories
{
    public interface IAccount
    {
        Task<Account> GetOneAccount(string email);
        Task InsertNewAccount(Account account);
        Task <(bool IsSuccess,string Message,int UserId,string UserName)> IsLogin(string email,string password);
        Task<(bool IsSuccess, string Message)> SignUp(Account account);
    }
}
