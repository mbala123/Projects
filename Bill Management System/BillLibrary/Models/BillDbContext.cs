using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Models
{
    public class BillDbContext : DbContext
    {
        public BillDbContext()
        {

        }

        public BillDbContext(DbContextOptions<BillDbContext> options) : base(options)
        {

        }

        public virtual DbSet<BillItems> Bills { get; set; }
        public virtual DbSet<UserDetails> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ZSCHN01LP0092;Initial Catalog=BillDB;User ID=sa;Password=Password@123;Trust Server Certificate=True");
        }
    }
}