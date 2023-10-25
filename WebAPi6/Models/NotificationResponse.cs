using Newtonsoft.Json;


namespace WebAPi6.Models
{
    public class NotificationResponse
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        public List<Cart> CartDetails { get; set; }
    }
}
