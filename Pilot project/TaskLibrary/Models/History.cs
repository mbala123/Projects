using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Models
{
    [Table("History")]
    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }
        [ForeignKey("TaskList")]
        public int TaskId { get; set; }
        [ForeignKey("UserRegistration")]
        public int UserId { get; set; }
        [ForeignKey("StatusLookUp")]
        public int PreviousStatusId { get; set; }

        [ForeignKey("StatusLookUp")]
        public int PresentStatusId { get; set; }

        [ForeignKey("PriorityLookUp")]
        public int PriorityId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [ForeignKey("TaskId")]
        public TaskList? TaskList { get; set; }
        [ForeignKey("PresentStatusId")]
        public StatusLookUp? PresentStatus { get; set; }
        [ForeignKey("PreviousStatusId")]
        public StatusLookUp? PreviousStatus { get; set; }
        [ForeignKey("PriorityId")]
        public PriorityLookUp? PresentPriority { get; set; }
    }
}
