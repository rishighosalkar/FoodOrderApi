using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPi6.Models
{
    public class User
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\d{10}$")]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public UserAddress Address { get; set; }
        public List<Order> Orders { get; set; }
        public List<Cart> Carts { get; set; }

    }
}
