using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPi6.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public DateTime OrderDate {  get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public int TotalAmount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string OrderStatus { get; set; }
    }
}
