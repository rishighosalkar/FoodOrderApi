using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebAPi6.Models
{
    public class RestaurantAddress
    {
        [Key]
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; } 
        public string Country { get; set; }
        [ForeignKey("Restaurant")]
        public int? RestaurantId { get; set; }

    }
}
