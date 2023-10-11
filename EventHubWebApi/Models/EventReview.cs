namespace EventHubWebApi.Models
{
    public class EventReview
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
