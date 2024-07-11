using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Models
{
    [Table("UserRegistration")]
    public class UserRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required (ErrorMessage ="User Name is Required")]
        [StringLength(20) ]
        public string UserName { get; set; }

        [Required (ErrorMessage =("Display Name is Required"))]
        [StringLength(30) ]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(20)]
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
