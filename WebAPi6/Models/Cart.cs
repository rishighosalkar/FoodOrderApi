using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebAPi6.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Meal")]
        public int MealId { get; set; }
        [ForeignKey("Meal")]
        public string MealName { get; set; }
        public int Quantity { get; set;}
        public int TotalPrice { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;
        [ForeignKey("Order")]
        [AllowNull]
        public int OrderId { get; set; }
    }
}
