using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPi6.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required]
        public string RestaurantUsername { get; set; }
        [Required]
        [MinLength(8)]
        public string RestaurantPassword { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string RestaurantDescription { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        public List<Meal> RestaurantMeals { get; set; }
        [Required]
        public RestaurantAddress Address { get; set; }
        /*[ForeignKey("Address")]
        public int Address { get; set; }*/

    }
}
