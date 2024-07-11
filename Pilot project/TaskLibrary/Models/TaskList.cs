using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskLibrary.Models
{
    [Table("TaskList")]
    public class TaskList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [ForeignKey("UserRegistration")]
        public int UserId { get; set; }

        [Required(ErrorMessage ="Task Name is Required")]
        [StringLength(50)]
        public string TaskName { get; set; }

        [Required(ErrorMessage ="Task Description is Required")]
        [StringLength(50)]
        public string TaskDescription { get; set; }

        public DateTime TaskDate { get; set; }

        [ForeignKey("StatusLookUp")]
        public int StatusId { get; set; }

        [ForeignKey("PriorityLookUp")]
        public int PriorityId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public StatusLookUp? StatusLookUp { get; set; }
        public PriorityLookUp? PriorityLookUp { get; set; }
    }
}
