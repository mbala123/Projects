using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FileLibrary.Models
{
    [Table("FileManager")]
    public class FileManager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? FileId { get; set; }
        [ForeignKey("Account")]
        public int UserId { get; set; }
        public string FileData { get; set; }
        public string? FileName { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string? SecurityType { get; set; }
        public string? Password { get; set; }
        public bool isDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Account? Account { get; set; }
        public Category? Category { get; set; }

    }


}
