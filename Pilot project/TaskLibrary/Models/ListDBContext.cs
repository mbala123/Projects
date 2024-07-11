using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Models
{
    public class ListDBContext : DbContext
    {
        public ListDBContext()
        {

        }
        public ListDBContext(DbContextOptions<ListDBContext> options) : base(options)
        {

        }
        public virtual DbSet<PriorityLookUp> PriorityLookUps { get; set; }
        public virtual DbSet<StatusLookUp> StatusLookUps { get; set; }
        public virtual DbSet<TaskList> Tasks { get; set; }
        public virtual DbSet<UserRegistration> UserRegistrations { get; set; }
       public virtual DbSet<History> Histories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ZSCHN01LP0092;Initial Catalog=TaskListDB;User ID=sa;Password=Password@123;Trust Server Certificate=True");
        }
    }
}
