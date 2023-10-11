using System.Text.Json.Serialization;

namespace EventHubWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PasswordHash { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Event> Events { get; set; } = new List<Event>();
        public List<EventReview> EventReviews { get; set; } = new List<EventReview>();
    }
}
