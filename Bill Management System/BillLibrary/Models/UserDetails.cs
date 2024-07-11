using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillLibrary.Models
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Address { get; set; }
        public int TotalAmount { get; set; }
        public List<BillItems>? Bills { get; set; }

    }
}