using System.ComponentModel.DataAnnotations;

namespace WebAPi6.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
