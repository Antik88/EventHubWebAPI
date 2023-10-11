using System.Text.Json.Serialization;

namespace EventHubWebApi.Models
{
    public class EventImages
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string ImgaePath { get; set; }

        [JsonIgnore]
        public Event Event { get; set; }
    }
}
