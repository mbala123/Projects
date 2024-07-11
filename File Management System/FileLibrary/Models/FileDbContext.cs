using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibrary.Models
{
    public class FileDbContext : DbContext
    {
        public FileDbContext()
        {

        }
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<FileManager> FileManagers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ZSCHN01LP0092;Initial Catalog=FileManagerDB;User ID=sa;Password=Password@123;Trust Server Certificate=True");
        }
    }
}
