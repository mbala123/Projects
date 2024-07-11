using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Models
{
    [Table("StatusLookUp")]
    public class StatusLookUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }

        [Required(ErrorMessage ="Status Type is Required")]
        [StringLength(50)]
        public string StatusType { get; set; }
    }
}
