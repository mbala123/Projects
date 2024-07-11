using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Models
{
    [Table("PriorityLookUp")]
    public class PriorityLookUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PriorityId { get; set; }

        [Required (ErrorMessage = "Priority Type is Reqy")]
        [StringLength (50)]
        public string PriorityType { get; set; }
    }
}
