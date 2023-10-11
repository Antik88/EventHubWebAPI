using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventHubWebApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string? EventName { get; set; }
        public string? Place { get; set; }
        public DateTime EventTime { get; set; }
        public string? Description { get; set; }
        public bool IsOpenEvent { get; set; }
        public EventCategory EventCategory { get; set; }
        public int OrganizerId { get; set; }

        [JsonIgnore]
        public List<User> Users { get; set; } = new List<User>();

        [JsonIgnore]
        public List<EventImages> EventImages { get; set; } = new List<EventImages>();

        [JsonIgnore]
        public List<EventReview> EventReviews { get; set; } = new List<EventReview>();
    }
}
