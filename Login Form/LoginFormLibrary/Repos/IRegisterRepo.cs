using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginFormLibrary.Models;

namespace LoginFormLibrary.Repos
{
    public interface IRegisterRepo
    {
        Task <Register> GetOne(string username);
        Task <List<Register>> GetAll();
        Task Insert(Register register);
        Task Update(string username,Register r);
        Task Delete(string username);

    }
}
