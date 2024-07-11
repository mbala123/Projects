using LoginFormLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginFormLibrary.Repos
{
    public class RegisterRepo:IRegisterRepo
    {
        LoginContext ctx=new LoginContext();

        public async Task<Register> GetOne(string username)
        {
            Register r = await (from s in ctx.Registers where s.username==username select s).FirstAsync();
            return r;
        }

        public async Task <List<Register>> GetAll()
        {
            List <Register> list = await ctx.Registers.ToListAsync();
            return list;
        }
        public async Task Insert(Register register)
        {
            await ctx.Registers.AddAsync(register);
            await ctx.SaveChangesAsync();
        }

        public async Task Update(string username,Register register)
        {
            Register r = await GetOne(username);
            //r.EmployeeName = register.EmployeeName;
          //  r.psword = password;
          
            await ctx.SaveChangesAsync();
        }

        public async Task Delete(string username)
        {
            Register r=await GetOne(username);
            ctx.Registers.Remove(r);    
            await ctx.SaveChangesAsync();
        }
    }
}
