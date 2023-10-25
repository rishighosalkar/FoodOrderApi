using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPi6.Models
{
    public class OrderConfirmation
    {
        [Key]
        public int ConfirmationId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UersId { get; set; }
        [Required]
        public string ConfirmStatus { get; set; }
    }
}
