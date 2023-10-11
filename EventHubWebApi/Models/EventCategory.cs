using System.Text.Json.Serialization;

namespace EventHubWebApi.Models
{
    public class EventCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
