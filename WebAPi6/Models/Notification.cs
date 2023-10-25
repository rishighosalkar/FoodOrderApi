using Newtonsoft.Json;
using WebAPi6.Helpers;

namespace WebAPi6.Models
{
    public class Notification
    {
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        public List<Cart> CartDetails { get; set; }
    }

    public class GoogleNotification
    {
        public class DataPayload
        {
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("message")]
            public string Message { get; set; }
            public List<Cart> CartDetails { get; set;}
        }
        [JsonProperty("priority")]
        public string Priority { get; set; } = "high";
        [JsonProperty("data")]
        public DataPayload Data { get; set; }
        [JsonProperty("notification")]
        public DataPayload Notification { get; set; }
    }
}
